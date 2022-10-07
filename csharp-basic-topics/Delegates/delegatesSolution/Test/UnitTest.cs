namespace Test;
using delegates;
[TestClass]
public class UnitTest
{
    public static EmployeeModel employeeModel = new EmployeeModel();
    [TestMethod]
    public void calculateEmployeeSalary_whenHoursWorked_is_greater_than_160()
    {
        decimal hoursWorked = 162.0M;
        decimal expectedResults = 24450M;
        decimal actualResults = employeeModel.calculateEmployeeSalary(hoursWorked, delegates.Program.printOverTimeAmount, delegates.Program.printTotalSalaryAmount);
        Assert.AreEqual(expectedResults, actualResults);
    }
    [TestMethod]
    public void calculateEmployeeSalary_whenHoursWorked_is_less_than_160()
    {
        decimal hoursWorked = 100.0M;
        decimal expectedResults = 15000M;
        decimal actualResults = employeeModel.calculateEmployeeSalary(hoursWorked, delegates.Program.printOverTimeAmount, delegates.Program.printTotalSalaryAmount);
        Assert.AreEqual(expectedResults, actualResults);
    }

    [TestMethod]
    public void calculateEmployeeSalary_whenHoursWorked_is_equal_to_160()
    {
        decimal hoursWorked = 160.0M;
        decimal expectedResults = 24000M;
        decimal actualResults = employeeModel.calculateEmployeeSalary(hoursWorked, delegates.Program.printOverTimeAmount, delegates.Program.printTotalSalaryAmount);
        Assert.AreEqual(expectedResults, actualResults);
    }
}