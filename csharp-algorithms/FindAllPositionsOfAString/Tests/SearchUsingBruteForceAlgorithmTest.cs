using FindAllPositionsOfAString;

namespace Tests;

[TestClass]
public class SearchUsingBruteForceAlgorithmTest
{
    [TestMethod]
    public void GivenLoremText_WhenSearchingLorem_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingBruteForceAlgorithm();
        var searchValue = "lorem";
        var searchText = "lorem ipsum dolor sit amet, consectetur adipiscing elit. lorem ipsum dolor sit amet.";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        var expectedPositions = new List<int> { 0, 57 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingNotFound_ThenThereShouldBeNoMatches()
    {
        var searcher = new SearchUsingBruteForceAlgorithm();
        var searchValue = "notfound";
        var searchText = "lorem ipsum dolor sit amet, consectetur adipiscing elit. lorem ipsum dolor sit amet.";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        Assert.IsTrue(positions.Count == 0);
    }
}
