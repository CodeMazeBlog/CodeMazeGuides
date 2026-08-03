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
        var searchText = "lorem";

        var searcher = new SearchUsingKMPAlgorithm(searchText, false, false);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        var expectedPositions = new List<int> { 0, 28, 56, 84 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseSensitive_ThenThereShouldBeTwoMatches()
    {
        var searchText = "lorem";

        var searcher = new SearchUsingKMPAlgorithm(searchText, false, true);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        var expectedPositions = new List<int> { 0, 56 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingNotFound_ThenThereShouldBeNoMatches()
    {
        var searchText = "notfound";

        var searcher = new SearchUsingKMPAlgorithm(searchText, false, true);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithWholeWords_ThenExpectException()
    {
        var searchText = "III";
        var text = "IIIIIII";

        var searcher = new SearchUsingKMPAlgorithm(searchText, true, true);
        Assert.ThrowsException<NotSupportedException>(() => searcher.FindAll(text));
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithoutWholeWords_ThenThereShouldBeFiveMatches()
    {
        var searchText = "III";
        var text = "IIIIIII";

        var searcher = new SearchUsingKMPAlgorithm(searchText, false, true);
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
            var searcher = new SearchUsingKMPAlgorithm(searchPair.SearchText, false, caseSensitive);
            var bruteForceSearcher = new SearchUsingIndexOf(searchPair.SearchText, false, caseSensitive);

            List<int> positions = searcher.FindAll(searchPair.Text);
            List<int> bruteForcePositions = bruteForceSearcher.FindAll(searchPair.Text);

            Assert.IsTrue(positions.Count == bruteForcePositions.Count);
            CollectionAssert.AreEqual(bruteForcePositions, positions);
        }
    }
}
