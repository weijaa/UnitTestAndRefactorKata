namespace UnitTestAndRefactorKata;

public interface IEmployeeRepo
{
    int GetHoursWorked(int employeeId, int month, int year);
}

public class EmployeeRepo : IEmployeeRepo
{
    public int GetHoursWorked(int employeeId, int month, int year)
    {
        return (int)(DateTime.Now - new DateTime(year, month, 1)).TotalHours;
    }
}

public class EmployeeSalaryCalculator
{
    private readonly IEmployeeRepo _employeeRepo = new EmployeeRepo();

    public EmployeeSalaryCalculator()
    {
        
    }
    public EmployeeSalaryCalculator(IEmployeeRepo employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    public decimal CalculateSalary(string employeeType, int employeeId, int month, int year)
    {
        var hoursWorked = GetHoursWorked(employeeId, month, year);
        decimal salary = 0;

        switch (employeeType)
        {
            case "Full-time":
                salary = 3000;
                break;
            case "Part-time":
                salary = hoursWorked * 20;
                break;
            default:
                throw new NotSupportedException("Unknown employee type");
        }

        return salary;
    }

    public virtual int GetHoursWorked(int employeeId, int month, int year)
    {
        var hoursWorked = _employeeRepo.GetHoursWorked(employeeId, month, year);
        return hoursWorked;
    }
}