namespace UnitTestAndRefactorKata;

public class EmployeeSalaryCalculator
{
    public decimal CalculateSalary(string employeeType, string employeeId, int month, int year)
    {
        var hoursWorked = GetHoursWorked(employeeId, month, year); // 從數據庫查詢工時
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
    private int GetHoursWorked(string employeeId, int month, int year)
    {
        return new Random().Next(100, 200);
    }
}