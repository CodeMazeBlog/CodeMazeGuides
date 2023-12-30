namespace ListExistsInAnotherCSharpTests;

[TestClass]
public class ListExistsInAnotherUnitTests
{
    private readonly CompareListsMethods _compareListsMethods = new();
    private readonly List<int> _firstList;
    private readonly List<int> _secondList;
    private readonly List<int> _thirdList;
    private readonly string _listName;

    public ListExistsInAnotherUnitTests()
    {
        _firstList = new List<int> { 0, 1, 2, 3, 4 };
        _secondList = new List<int> { 5, 6, 7, 8, 9 };
        _thirdList = new List<int> { 0, 1, 2, 3, 5 };
        _listName = string.Empty;
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingIntersect_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingIntersect(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingIntersect(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingIteration_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingIteration(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingIteration(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingAnyContains_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingAnyContains(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingAnyContains(_firstList, _secondList, _listName));
    }

    [TestMethod]
    public void GivenTwoLists_WhenComparedUsingExcept_ValidateCorrectResults()
    {
        Assert.IsTrue(_compareListsMethods.CompareListUsingExcept(_firstList, _thirdList, _listName));
        Assert.IsFalse(_compareListsMethods.CompareListUsingExcept(_firstList, _secondList, _listName));
    }
}