using IndexOutOfRangeExceptionProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class IndexOutOfRangeExceptionUnitTest
{
    private readonly UtilityHelper utilityHelper = new();

    [TestMethod]
    public void WhenExceptionFlagIsTrueForUpperBoundMethod_ThenRaiseException()
    {
        var testArray = () =>
        {
            utilityHelper.UpperBoundMethod(true);
        };

        Assert.ThrowsExactly<IndexOutOfRangeException>(testArray);
    }

    [TestMethod]
    public void WhenExceptionFlagIsTrueForCustomLowerBoundMethod_ThenRaiseException()
    {
        var testArray = () =>
        {
            utilityHelper.CustomLowerBoundMethod(2, true);
        };

        Assert.ThrowsExactly<IndexOutOfRangeException>(testArray);
    }

    [TestMethod]
    public void WhenExceptionFlagIsTrueAndInvalidSearchArgumentForListIndexOfMethod_ThenRaiseException()
    {
        var testArray = () =>
        {
            utilityHelper.ListIndexOfMethod(11, true);
        };

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(testArray);
    }

    [TestMethod]
    public void WhenExceptionFlagIsTrueForAssignFirstArrayElementToSecondArrayMethod_ThenRaiseException()
    {
        var testArray = () =>
        {
            utilityHelper.AssignFirstArrayElementToSecondArrayMethod(true);
        };

        Assert.ThrowsExactly<IndexOutOfRangeException>(testArray);
    }

    [TestMethod]
    public void WhenExceptionFlagIsTrueForIndexAndValueMethod_ThenRaiseException()
    {
        var testArray = () =>
        {
            utilityHelper.IndexAndValueMethod(true);
        };

        Assert.ThrowsExactly<IndexOutOfRangeException>(testArray);
    }

    [TestMethod]
    public void WhenExceptionFlagIsTrueForDataTableMethod_ThenRaiseException()
    {
        var testArray = () =>
        {
            utilityHelper.DataTableMethod(true);
        };

        Assert.ThrowsExactly<IndexOutOfRangeException>(testArray);
    }

    [TestMethod]
    public void WhenExceptionFlagIsTrueForIndexFromEndMethod_ThenRaiseException()
    {
        var testArray = () =>
        {
            utilityHelper.IndexFromEndMethod(true);
        };

        Assert.ThrowsExactly<IndexOutOfRangeException>(testArray);
    }

    [TestMethod]
    public void WhenExceptionFlagIsTrueForRangeMethod_ThenRaiseArgumentOutOfRangeException()
    {
        var testArray = () =>
        {
            utilityHelper.RangeMethod(true);
        };

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(testArray);
    }
}
