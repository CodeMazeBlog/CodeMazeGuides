using EnumerateAnEnumInCSharp;
using DayOfWeek = EnumerateAnEnumInCSharp.DayOfWeek;

namespace Tests;

[TestClass]
public class EnumerateAnEnumInCSharpUnitTests
{
    [TestMethod]
    public void GivenDaysOfWeek_ThenArrayOfValuesIsReturned()
    {
        var result = EnumHelper.GetValues(typeof(DayOfWeek));

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType<DayOfWeek[]>(result);
        TestAllDaysInResult(result);
    }

    [TestMethod]
    public void GivenDaysOfWeek_ThenTypedArrayOfValuesIsReturned()
    {
        var result = EnumHelper.GetValues<DayOfWeek>();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType<DayOfWeek[]>(result);
        TestAllDaysInResult(result);
    }

    [TestMethod]
    public void GivenDaysOfWeek_WhenEnumValuesFromReflection_ThenValuesArrayIsReturned()
    {
        var result = EnumHelper.GetValuesWithReflection<DayOfWeek>();

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType<DayOfWeek[]>(result);
        TestAllDaysInResult(result);
    }

    [TestMethod]
    public void GivenANegativeMember_WhenGetValues_ThenItComesLast()
    {
        var result = Enum.GetValues<OrderStatus>();

        Assert.AreEqual(OrderStatus.Cancelled, result[^1]);
    }

    [TestMethod]
    public void GivenTwoMembersWithOneValue_WhenGetValues_ThenTheValueAppearsTwice()
    {
        var result = Enum.GetValues<OrderStatus>();

        Assert.AreEqual(5, result.Length);
        Assert.AreEqual(2, result.Count(status => status == OrderStatus.Shipped));
    }

    [TestMethod]
    public void GivenTwoMembersWithOneValue_WhenGetNames_ThenBothNamesAreReturned()
    {
        var result = Enum.GetNames<OrderStatus>();

        CollectionAssert.AreEquivalent(
            new[] { "Cancelled", "Pending", "Paid", "Shipped", "Dispatched" },
            result);
    }

    private static void TestAllDaysInResult(System.Collections.ICollection result)
    {
        Assert.AreEqual(7, result.Count);

        CollectionAssert.Contains(result, DayOfWeek.Monday);
        CollectionAssert.Contains(result, DayOfWeek.Tuesday);
        CollectionAssert.Contains(result, DayOfWeek.Wednesday);
        CollectionAssert.Contains(result, DayOfWeek.Thursday);
        CollectionAssert.Contains(result, DayOfWeek.Friday);
        CollectionAssert.Contains(result, DayOfWeek.Saturday);
        CollectionAssert.Contains(result, DayOfWeek.Sunday);
    }
}
