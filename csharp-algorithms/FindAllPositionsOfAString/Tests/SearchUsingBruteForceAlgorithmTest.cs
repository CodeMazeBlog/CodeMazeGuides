﻿using FindAllPositionsOfAString.Algorithms;

namespace Tests;

[TestClass]
public class SearchUsingBruteForceAlgorithmTest
{
    [TestMethod]
    public void GivenLoremText_WhenSearchingLoremCaseInsensitive_ThenThereShouldBeFourMatches()
    {
        var searcher = new SearchUsingBruteForceAlgorithm();
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
        var searcher = new SearchUsingBruteForceAlgorithm();
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
        var searcher = new SearchUsingBruteForceAlgorithm();
        var searchValue = "notfound";
        var searchText = "lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET. lorem ipsum dolor sit amet, LoreM IPSUM DOLOR SIT AMET.";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        Assert.IsTrue(positions.Count == 0);
    }

    [TestMethod]
    public void GivenIIIIIII_WhenSearchingIIIWithWholeWords_ThenThereShouldBeTwoMatches()
    {
        var searcher = new SearchUsingBruteForceAlgorithm();
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
        var searcher = new SearchUsingBruteForceAlgorithm();
        searcher.SkipWholeFoundText = false;
        var searchValue = "III";
        var searchText = "IIIIIII";

        searcher.Initialize(searchValue);
        List<int> positions = searcher.FindAll(searchText);

        var expectedPositions = new List<int> { 0, 1, 2, 3, 4 };
        CollectionAssert.AreEqual(expectedPositions, positions);
    }
}