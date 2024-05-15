using UsingExceptInCSharp;

namespace UsingExceptInCSharpTests;

[TestClass]
public class UsingExceptUnitTests
{
    private readonly ExceptMethodExamples _examples = new();
    private readonly EmployeeComparer _employeeComparer = new ();

    [TestMethod]
    public void GivenAllEmployees_WhenExceptInvoked_ThenVerifyThatNoSalesEmployeesReturned()
    {
        var nonSales = _examples.GetEmployeesNotInSales();
        var maryRecord = nonSales.Find(i => i.Name == "Mary Jane");
        var sheilaRecord = nonSales.Find(i => i.Name == "Sheila Foxx");

        Assert.IsInstanceOfType(nonSales, typeof(List<Employee>));
        Assert.IsNull(maryRecord);
        Assert.IsNotNull(sheilaRecord);
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

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void GivenAllEmployees_WhenExceptInvokedAgainstNull_ThenVerifyThatExceptionThrown()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };
        List<int> emptyList = null;

        var result = numbers.Except(emptyList);
    }

    [TestMethod]
    public void GivenAllEmployees_WhenExceptInvoked_ThenVerifyThatNoSalesEmployeesReturnedWithComparer()
    {
        var nonSales = _examples.GetEmployeesNotInSalesUsingComparer();
        var expectedRecord = new Employee { ID = 4, Name = "Sheila Foxx", Age = 31, Department = "Marketing" };
        var sheilaRecord = nonSales.Find(i => i.Name == "Sheila Foxx");
        var comparison = _employeeComparer.Equals(expectedRecord, sheilaRecord);

        Assert.IsInstanceOfType(nonSales, typeof(List<Employee>));
        Assert.IsTrue(comparison);
        Assert.IsNotNull(sheilaRecord);
    }
}