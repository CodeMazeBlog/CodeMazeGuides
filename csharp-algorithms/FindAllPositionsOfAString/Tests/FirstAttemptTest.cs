using FindAllPositionsOfAString.Algorithms;

namespace Tests;

[TestClass]
public class FirstAttemptTest
{
    private readonly string _partOfLoremIpsumText = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseSensitive_ThenThereShouldBeTwoMatches()
    {
        var searchText = "lorem";

        List<int> positions = FirstAttempt.FindAll(_partOfLoremIpsumText, searchText);

        var expectedPositions = new List<int> { 0, 56 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }

    [TestMethod]
    public void GivenLoremText_WhenSearchingNotFound_ThenThereShouldBeNoMatches()
    {
        var searchText = "notfound";

        List<int> positions = FirstAttempt.FindAll(_partOfLoremIpsumText, searchText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIII_ThenThereShouldBeFiveMatches()
    {
        var searchText = "III";
        var text = "IIIIIII";

        List<int> positions = FirstAttempt.FindAll(text, searchText);

        var expectedPositions = new List<int> { 0, 1, 2, 3, 4 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }
}
