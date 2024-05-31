using FindAllPositionsOfAString;

namespace Tests;

[TestClass]
public class SearchUsingRegexTest
{
    [TestMethod]
    public void GivenLoremText_WhenSearchingLorem_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingRegex();
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
        var searcher = new SearchUsingRegex();
        var searchValue = "notfound";
        var searchText = "lorem ipsum dolor sit amet, consectetur adipiscing elit. lorem ipsum dolor sit amet.";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenSearchConditions_WhenRunningSearcher_ThenSameResultsAreExpectedAsUsingBruteForceSearcher()
    {
        foreach (SearchPair searchPair in SearchingSamples.SampleForProgram())
        {
            var searcher = new SearchUsingKMPAlgorithm();
            searcher.Initialize(searchPair.SearchValue);

            var bruteForceSearcher = new SearchUsingBruteForceAlgorithm();
            bruteForceSearcher.Initialize(searchPair.SearchValue);

            List<int> positions = searcher.FindAll(searchPair.Text);
            List<int> bruteForcePositions = bruteForceSearcher.FindAll(searchPair.Text);

            Assert.IsTrue(positions.Count == bruteForcePositions.Count);
            CollectionAssert.AreEqual(bruteForcePositions, positions);
        }
    }
}

