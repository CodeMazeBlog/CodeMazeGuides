using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;

namespace Tests;

[TestClass]
public class SearchUsingKMPAlgorithmTest
{
    private readonly string _partOfLoremIpsumText = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseInsensitive_ThenThereShouldBeFourMatches()
    {
        var searcher = new SearchUsingKMPAlgorithm();
        searcher.CaseSensitive = false;
        var searchText = "lorem";

        searcher.Initialize(searchText);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        var expectedPositions = new List<int> { 0, 28, 56, 84 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseSensitive_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingKMPAlgorithm();
        searcher.CaseSensitive = true;
        var searchText = "lorem";

        searcher.Initialize(searchText);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        var expectedPositions = new List<int> { 0, 56 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingNotFound_ThenThereShouldBeNoMatches()
    {
        var searcher = new SearchUsingKMPAlgorithm();
        var searchText = "notfound";

        searcher.Initialize(searchText);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithWholeWords_ThenExpectException()
    {
        var searcher = new SearchUsingKMPAlgorithm();
        searcher.SkipWholeFoundText = true;
        var searchText = "III";
        var text = "IIIIIII";

        searcher.Initialize(searchText);
        Assert.ThrowsException<NotSupportedException>(() => searcher.FindAll(text));
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithoutWholeWords_ThenThereShouldBeFiveMatches()
    {
        var searcher = new SearchUsingKMPAlgorithm();
        searcher.SkipWholeFoundText = false;
        var searchText = "III";
        var text = "IIIIIII";

        searcher.Initialize(searchText);
        List<int> positions = searcher.FindAll(text);

        var expectedPositions = new List<int> { 0, 1, 2, 3, 4 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    [DataRow(true)]
    [DataRow(false)]
    public void GivenSearchConditions_WhenRunningSearcher_ThenSameResultsAreExpectedAsUsingIndexOfSearcher(bool caseSensitive)
    {
        foreach (SearchPair searchPair in SearchingSamples.SampleForProgram())
        {
            var searcher = new SearchUsingKMPAlgorithm();
            searcher.CaseSensitive = caseSensitive;
            searcher.SkipWholeFoundText = false;
            searcher.Initialize(searchPair.SearchText);

            var bruteForceSearcher = new SearchUsingIndexOf();
            bruteForceSearcher.CaseSensitive = caseSensitive;
            bruteForceSearcher.SkipWholeFoundText = false;
            bruteForceSearcher.Initialize(searchPair.SearchText);

            List<int> positions = searcher.FindAll(searchPair.Text);
            List<int> bruteForcePositions = bruteForceSearcher.FindAll(searchPair.Text);

            Assert.IsTrue(positions.Count == bruteForcePositions.Count);
            CollectionAssert.AreEqual(bruteForcePositions, positions);
        }
    }
}
