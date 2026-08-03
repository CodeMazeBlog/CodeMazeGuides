using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;
using System.Buffers;
using static System.Net.Mime.MediaTypeNames;

namespace Tests;

[TestClass]
public class SearchUsingIndexOfTest
{
    private readonly string _partOfLoremIpsumText = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseInsensitive_ThenThereShouldBeFourMatches()
    {
        var searchText = "lorem";

        var searcher = new SearchUsingIndexOf(searchText, false, false);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        var expectedPositions = new List<int> { 0, 28, 56, 84 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseSensitive_ThenThereShouldBeTwoMatches()
    {
        var searchText = "lorem";

        var searcher = new SearchUsingIndexOf(searchText, false, true);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        var expectedPositions = new List<int> { 0, 56 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingNotFound_ThenThereShouldBeNoMatches()
    {
        var searchText = "notfound";

        var searcher = new SearchUsingIndexOf(searchText, false, true);
        List<int> positions = searcher.FindAll(_partOfLoremIpsumText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithWholeWords_ThenThereShouldBeTwoMatches()
    {
        var searchText = "III";
        var text = "IIIIIII";

        var searcher = new SearchUsingIndexOf(searchText, true, true);
        List<int> positions = searcher.FindAll(text);

        var expectedPositions = new List<int> { 0, 3 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithoutWholeWords_ThenThereShouldBeFiveMatches()
    {
        var searchText = "III";
        var text = "IIIIIII";

        var searcher = new SearchUsingIndexOf(searchText, false, true);
        List<int> positions = searcher.FindAll(text);

        var expectedPositions = new List<int> { 0, 1, 2, 3, 4 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }
}
