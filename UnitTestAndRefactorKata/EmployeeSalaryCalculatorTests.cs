namespace UnitTestAndRefactorKata;
//break dependency by pass value in legacy project
//break dependency by extract and override
//break dependency by create interface

public class Tests
{
    [SetUp]
    public void Setup()
    { }

    [Test]
    public void full_time_should_get_3000()
    {
        var employeeSalaryCalculator = new EmployeeSalaryCalculator();
        var calculateSalary = employeeSalaryCalculator.CalculateSalary("Full-time", 1, 1, 2021);
        Assert.That(calculateSalary, Is.EqualTo(3000));
    }

    [Test]
    public void part_time_should_get_calculator()
    {
        var fakeEmployeeRepo = new FakeEmployeeRepo();
        var employeeSalaryCalculator = new EmployeeSalaryCalculator(fakeEmployeeRepo);
        var calculateSalary = employeeSalaryCalculator.CalculateSalary("Part-time", 1, 1, 2021);
        Assert.That(calculateSalary, Is.EqualTo(30*20));
    }
}

public class FakeEmployeeRepo : IEmployeeRepo
{
    public int GetHoursWorked(int employeeId, int month, int year)
    {
        return 30;
    }
}