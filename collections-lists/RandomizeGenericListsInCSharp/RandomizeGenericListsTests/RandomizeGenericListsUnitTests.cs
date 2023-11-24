using RandomizeGenericListsInCSharp;

namespace RandomizeGenericListsTests;

[TestClass]
public class RandomizeGenericListsUnitTests
{
    private readonly RandomizeGenericListsMethods _randomizeListObj;
    private readonly List<int> _orderedList;

    public RandomizeGenericListsUnitTests()
    {
        _randomizeListObj = new RandomizeGenericListsMethods();
        _orderedList = _randomizeListObj.OrderedInts(1000000);
    }

    [TestMethod]
    public void GivenAnOrderedList_WhenNotEmpty_VerifyShuffleGuid()
    {
        var shuffledList = _randomizeListObj.GenerateRandomOrderByGuid(_orderedList);

        var firstVal = shuffledList.First();
        var lastVal = shuffledList.Last();
        
        Assert.AreNotEqual(firstVal, 0);
        Assert.AreNotEqual(lastVal, 999999);
    }

    [TestMethod]
    public void GivenAnOrderedList_WhenNotEmpty_VerifyShuffleLoop()
    {
        var shuffledList = _randomizeListObj.GenerateRandomLoop(_orderedList);

        var firstVal = shuffledList.First();
        var lastVal = shuffledList.Last();

        Assert.AreNotEqual(firstVal, 0);
        Assert.AreNotEqual(lastVal, 999999);
    }

    [TestMethod]
    public void GivenAnOrderedList_WhenNotEmpty_VerifyRandomOrderby()
    {
        var shuffledList = _randomizeListObj.GenerateRandomOrderBy(_orderedList);

        var firstVal = shuffledList.First();
        var lastVal = shuffledList.Last();

        Assert.AreNotEqual(firstVal, 0);
        Assert.AreNotEqual(lastVal, 999999);
    }

    [TestMethod]
    public void GivenAnInteger_WhenListIsEmpty_VerifyOrderedListGenerated()
    {
        var firstVal = _orderedList.First();
        var lastVal = _orderedList.Last();

        Assert.AreEqual(firstVal, 0);
        Assert.AreEqual(lastVal, 999999);
        Assert.IsInstanceOfType(_orderedList, typeof(List<int>));
    }
}