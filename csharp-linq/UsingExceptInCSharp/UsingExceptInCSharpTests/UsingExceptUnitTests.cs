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
        Assert.HasCount(8, nonSales);
        Assert.IsNull(maryRecord);
        Assert.IsNotNull(sheilaRecord);
    }

    [TestMethod]
    public void GivenDuplicatesInFirstSequence_WhenExceptInvoked_ThenVerifyThatResultIsDistinct()
    {
        var result = _examples.GetDistinctDifference();

        CollectionAssert.AreEqual(new List<int> { 1, 2, 4 }, result);
    }

    [TestMethod]
    public void GivenCopiesOfSalesEmployees_WhenExceptInvokedWithoutComparer_ThenVerifyThatNothingIsRemoved()
    {
        var result = _examples.GetEmployeesNotInSalesFromCopies();

        Assert.HasCount(12, result);
    }

    [TestMethod]
    public void GivenAllEmployees_WhenExceptInvokedIgnoreCase_ThenVerifyThatNoITEmployeesReturned()
    {
        var nonIT = _examples.GetEmployeesNotInITIgnoreCase();

        Assert.IsNotNull(nonIT);
        Assert.IsInstanceOfType(nonIT, typeof(List<string>));
        Assert.HasCount(10, nonIT);
        Assert.DoesNotContain("Ava Knowles", nonIT);
        Assert.DoesNotContain("Grace Jones", nonIT);
    }

    [TestMethod]
    public void GivenAllEmployees_WhenExceptInvokedAgainstNull_ThenVerifyThatExceptionThrown()
    {
        var numbers = new List<int> { 1, 2, 3, 4 };
        List<int>? nullList = null;

        Assert.ThrowsExactly<ArgumentNullException>(() => numbers.Except(nullList!));
    }

    [TestMethod]
    public void GivenAllEmployees_WhenExceptInvoked_ThenVerifyThatNoSalesEmployeesReturnedWithComparer()
    {
        var nonSales = _examples.GetEmployeesNotInSalesUsingComparer();
        var expectedRecord = new Employee { ID = 4, Name = "Sheila Foxx", Age = 31, Department = "Marketing" };
        var sheilaRecord = nonSales.Find(i => i.Name == "Sheila Foxx");
        var comparison = _employeeComparer.Equals(expectedRecord, sheilaRecord);

        Assert.IsInstanceOfType(nonSales, typeof(List<Employee>));
        Assert.HasCount(8, nonSales);
        Assert.IsTrue(comparison);
        Assert.IsNotNull(sheilaRecord);
    }

    [TestMethod]
    public void GivenRecords_WhenExceptInvokedWithoutComparer_ThenVerifyThatValueEqualityIsUsed()
    {
        var result = _examples.GetEmployeeRecordsNotInSales();

        CollectionAssert.AreEqual(new List<string> { "Sheila Foxx", "Grace Jones" }, result.Select(e => e.Name).ToList());
    }

    [TestMethod]
    public void GivenITEmployeeIDs_WhenExceptByInvoked_ThenVerifyThatNoITEmployeesReturned()
    {
        var result = _examples.GetEmployeesNotInITByID();

        Assert.HasCount(10, result);
        Assert.IsNull(result.Find(e => e.ID == 6));
        Assert.IsNull(result.Find(e => e.ID == 7));
    }
}
