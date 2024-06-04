using FindAllPositionsOfAString.Algorithms;
using FindAllPositionsOfAString.Samples;
using System.Buffers;
using static System.Net.Mime.MediaTypeNames;

namespace Tests;

[TestClass]
public class SearchUsingIndexOfTest
{
    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseInsensitive_ThenThereShouldBeFourMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.CaseSensitive = false;
        var searchText = "lorem";
        var text = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

        List<int> positions = searcher.FindAll(text, searchText);

        var expectedPositions = new List<int> { 0, 28, 56, 84 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseSensitive_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.CaseSensitive = true;
        var searchText = "lorem";
        var text = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

        List<int> positions = searcher.FindAll(text, searchText);

        var expectedPositions = new List<int> { 0, 56 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingNotFound_ThenThereShouldBeNoMatches()
    {
        var searcher = new SearchUsingIndexOf();
        var searchText = "notfound";
        var text = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

        List<int> positions = searcher.FindAll(text, searchText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithWholeWords_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.SkipWholeFoundText = true;
        var searchText = "III";
        var text = "IIIIIII";

        List<int> positions = searcher.FindAll(text, searchText);

        var expectedPositions = new List<int> { 0, 3 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithoutWholeWords_ThenThereShouldBeFiveMatches()
    {
        var searcher = new SearchUsingIndexOf();
        searcher.SkipWholeFoundText = false;
        var searchText = "III";
        var text = "IIIIIII";

        List<int> positions = searcher.FindAll(text, searchText);

        var expectedPositions = new List<int> { 0, 1, 2, 3, 4 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }
}
