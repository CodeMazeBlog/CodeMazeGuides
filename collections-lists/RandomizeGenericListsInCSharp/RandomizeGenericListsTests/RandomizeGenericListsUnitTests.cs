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
    public void GivenAnOrderedList_WhenNotEmpty_VerifyShuffleLoop()
    {
        var listToShuffle = new List<int>(_orderedList);

        var shuffledList = _randomizeListObj.GenerateRandomLoop(listToShuffle);

        Assert.AreSame(listToShuffle, shuffledList);
        CollectionAssert.AreEquivalent(_orderedList, shuffledList);
        CollectionAssert.AreNotEqual(_orderedList, shuffledList);
    }

    [TestMethod]
    public void GivenAnOrderedList_WhenNotEmpty_VerifyRandomShuffle()
    {
        var listToShuffle = new List<int>(_orderedList);

        var shuffledList = _randomizeListObj.GenerateRandomShuffle(listToShuffle);

        Assert.AreSame(listToShuffle, shuffledList);
        CollectionAssert.AreEquivalent(_orderedList, shuffledList);
        CollectionAssert.AreNotEqual(_orderedList, shuffledList);
    }

    [TestMethod]
    public void GivenAnOrderedList_WhenNotEmpty_VerifyLinqShuffle()
    {
        var shuffledList = _randomizeListObj.GenerateLinqShuffle(_orderedList);

        Assert.AreNotSame(_orderedList, shuffledList);
        CollectionAssert.AreEquivalent(_orderedList, shuffledList);
        CollectionAssert.AreNotEqual(_orderedList, shuffledList);
    }

    [TestMethod]
    public void GivenAnOrderedList_WhenNotEmpty_VerifyRandomOrderby()
    {
        var shuffledList = _randomizeListObj.GenerateRandomOrderBy(_orderedList);

        Assert.AreNotSame(_orderedList, shuffledList);
        CollectionAssert.AreEquivalent(_orderedList, shuffledList);
        CollectionAssert.AreNotEqual(_orderedList, shuffledList);
    }

    [TestMethod]
    public void GivenAnOrderedList_WhenNotEmpty_VerifyShuffleGuid()
    {
        var shuffledList = _randomizeListObj.GenerateRandomOrderByGuid(_orderedList);

        Assert.AreNotSame(_orderedList, shuffledList);
        CollectionAssert.AreEquivalent(_orderedList, shuffledList);
        CollectionAssert.AreNotEqual(_orderedList, shuffledList);
    }

    [TestMethod]
    public void GivenAThreeElementList_WhenShuffledManyTimes_VerifyFisherYatesProducesEveryOrder()
    {
        var counts = _randomizeListObj.CountOrders(_randomizeListObj.GenerateRandomLoop, 60_000);

        Assert.HasCount(6, counts);
        Assert.AreEqual(60_000, counts.Values.Sum());
    }

    [TestMethod]
    public void GivenAnInteger_WhenListIsEmpty_VerifyOrderedListGenerated()
    {
        Assert.AreEqual(0, _orderedList.First());
        Assert.AreEqual(999999, _orderedList.Last());
        Assert.HasCount(1000000, _orderedList);
    }
}
