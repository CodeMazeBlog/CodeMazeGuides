namespace ListExistsInAnotherCSharpTests;

[TestClass]
public class ListExistsInAnotherUnitTests
{
    private readonly CompareListsMethods _compareListsMethods = new();
    private readonly List<int> _firstList;
    private readonly List<int> _secondList;
    private readonly List<int> _thirdList;

    public ListExistsInAnotherUnitTests()
    {
        _firstList = new List<int> { 0, 1, 2, 3, 4 };
        _secondList = new List<int> { 5, 6, 7, 8, 9 };
        _thirdList = new List<int> { 0, 1, 2, 3, 5 };
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingIntersect_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingIntersect(_firstList, _thirdList));
        Assert.IsFalse(_compareListsMethods.CompareListUsingIntersect(_firstList, _secondList));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingIteration_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingIteration(_firstList, _thirdList));
        Assert.IsFalse(_compareListsMethods.CompareListUsingIteration(_firstList, _secondList));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingAnyContains_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingAnyContains(_firstList, _thirdList));
        Assert.IsFalse(_compareListsMethods.CompareListUsingAnyContains(_firstList, _secondList));
    }
}