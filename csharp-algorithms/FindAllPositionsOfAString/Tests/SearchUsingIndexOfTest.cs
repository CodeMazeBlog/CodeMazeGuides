using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;

namespace Tests;

[TestClass]
public class SearchUsingIndexOfTest
{
    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseInsensitive_ThenThereShouldBeFourMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.CaseSensitive = false;
        var searchValue = "lorem";
        var searchText = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        var expectedPositions = new List<int> { 0, 28, 56, 84 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseSensitive_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.CaseSensitive = true;
        var searchValue = "lorem";
        var searchText = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        var expectedPositions = new List<int> { 0, 56 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingNotFound_ThenThereShouldBeNoMatches()
    {
        var searcher = new SearchUsingIndexOf();
        var searchValue = "notfound";
        var searchText = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithWholeWords_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.SkipWholeFoundText = true;
        var searchValue = "III";
        var searchText = "IIIIIII";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        var expectedPositions = new List<int> { 0, 3 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithoutWholeWords_ThenThereShouldBeFiveMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.SkipWholeFoundText = false;
        var searchValue = "III";
        var searchText = "IIIIIII";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        var expectedPositions = new List<int> { 0, 1, 2, 3, 4 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    [DataRow(true, true)]
    [DataRow(true, false)]
    [DataRow(false, true)]
    [DataRow(false, false)]
    public void GivenSearchConditions_WhenRunningSearcher_ThenSameResultsAreExpectedAsUsingBruteForceSearcher(bool caseSensitive, bool skipWholeWords)
    {
        foreach (SearchPair searchPair in SearchingSamples.SampleForProgram())
        {
            var searcher = new SearchUsingIndexOf();
            searcher.CaseSensitive = caseSensitive;
            searcher.SkipWholeFoundText = skipWholeWords;
            searcher.Initialize(searchPair.SearchValue);

            var bruteForceSearcher = new SearchUsingBruteForceAlgorithm();
            bruteForceSearcher.CaseSensitive = caseSensitive;
            bruteForceSearcher.SkipWholeFoundText = skipWholeWords;
            bruteForceSearcher.Initialize(searchPair.SearchValue);

            List<int> positions = searcher.FindAll(searchPair.Text);
            List<int> bruteForcePositions = bruteForceSearcher.FindAll(searchPair.Text);

            Assert.IsTrue(positions.Count == bruteForcePositions.Count);
            CollectionAssert.AreEqual(bruteForcePositions, positions);
        }
    }
}
