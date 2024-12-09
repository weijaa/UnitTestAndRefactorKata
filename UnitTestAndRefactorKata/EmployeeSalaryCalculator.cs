namespace UnitTestAndRefactorKata;

public class EmployeeRepo
{
    public int GetHoursWorked(string employeeId, int month, int year)
    {
        return (int)(DateTime.Now - new DateTime(year, month, 1)).TotalHours;
    }
}

public class EmployeeSalaryCalculator
{
    private readonly EmployeeRepo _employeeRepo = new EmployeeRepo();

    public decimal CalculateSalary(string employeeType, string employeeId, int month, int year)
    {
        var hoursWorked = _employeeRepo.GetHoursWorked(employeeId, month, year); 
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
}