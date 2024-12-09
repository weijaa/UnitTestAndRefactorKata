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
        var employeeSalaryCalculator = new EmployeeSalaryCalculator();
        var hoursWorked = 20;
        var calculateSalary = employeeSalaryCalculator.Salary("Part-time", hoursWorked );
        Assert.That(calculateSalary, Is.EqualTo(hoursWorked*20));
    }
}