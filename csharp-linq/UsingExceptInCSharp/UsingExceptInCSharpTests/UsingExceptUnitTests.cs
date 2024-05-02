using UsingExceptInCSharp;

namespace UsingExceptInCSharpTests;

[TestClass]
public class UsingExceptUnitTests
{
    private readonly ExceptMethodExamples _examples = new();

    [TestMethod]
    public void GivenAllEmployees_WhenExceptInvoked_ThenVerifyThatNoSalesEmployeesReturned()
    {
        var nonSales = _examples.GetEmployeesNotInSales();
        var maryRecord = new Employee { ID = 12, Name = "Mary Jane", Age = 35, Department = "Sales" };
        var sheilaRecord = new Employee { ID = 4, Name = "Sheila Foxx", Age = 31, Department = "Marketing" };

        Assert.IsNotNull(nonSales);
        Assert.IsInstanceOfType(nonSales, typeof(List<Employee>));
        Assert.IsFalse(nonSales.Contains<Employee>(maryRecord));
        Assert.IsTrue(nonSales.Contains<Employee>(sheilaRecord));
    }

    [TestMethod]
    public void GivenAllEmployees_WhenExceptInvokedIgnoreCase_ThenVerifyThatNoITEmployeesReturned()
    {
        var nonIT = _examples.GetEmployeesNotInITIgnoreCase();

        Assert.IsNotNull(nonIT);
        Assert.IsInstanceOfType(nonIT, typeof(List<string>));
        Assert.IsFalse(nonIT.Contains("ava knowles"));
        Assert.IsFalse(nonIT.Contains("grace jones"));
    }
}