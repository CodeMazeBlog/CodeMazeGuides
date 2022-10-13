namespace TestActionAndFuncDelegates;
using ActionAndFunctionDelegates;
using EmloyeeModel;

[TestClass]
public class UnitTest
{
    public static EmployeeModel employeeModel = new EmployeeModel();
    [TestMethod]
    public void WhenWorkedHoursIsGreaterThan60_MethodReturnsCorrectTotalSalary()
    {
        // arrange
        decimal hoursWorked = 162.0M;
        decimal expectedResults = 24450M;
        //act

        decimal actualResults = employeeModel.CalculateEmployeeSalary(hoursWorked, ActionAndFunctionDelegates.Program.PrintOverTimeAmount, ActionAndFunctionDelegates.Program.PrintTotalSalaryAmount);
        //assert

        Assert.AreEqual(expectedResults, actualResults);
    }
    [TestMethod]
    public void WhenWorkedHoursIsLessThan60_MethodReturnsCorrectTotalSalary()
    {
        // arrange
        decimal hoursWorked = 100.0M;
        decimal expectedResults = 15000M;
        
        //act

        decimal actualResults = employeeModel.CalculateEmployeeSalary(hoursWorked, ActionAndFunctionDelegates.Program.PrintOverTimeAmount, ActionAndFunctionDelegates.Program.PrintTotalSalaryAmount);
        // assert

        Assert.AreEqual(expectedResults, actualResults);
    }

    [TestMethod]
    public void WhenWorkedHoursIs60_MethodReturnsCorrectTotalSalary()
    {
        // arrange
        decimal hoursWorked = 160.0M;
        decimal expectedResults = 24000M;

        // act

        decimal actualResults = employeeModel.CalculateEmployeeSalary(hoursWorked, ActionAndFunctionDelegates.Program.PrintOverTimeAmount, ActionAndFunctionDelegates.Program.PrintTotalSalaryAmount);
        
        // assert
       
        Assert.AreEqual(expectedResults, actualResults);
    }
}
