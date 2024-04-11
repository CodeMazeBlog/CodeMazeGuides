[TestFixture]
public class LinqTests
{
    [Test]
    public void Given_InputStringAndSearchString_When_FindAllIndexesWithLINQCalled_Then_ReturnListOfIndexes()
    {
        // Given
        var input = "Lorem ipsum dolor sit amet, consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan.";
        var search = "ip";
        var expectedIndexes = new List<int> { 6, 42, 53, 70, 85 };

        // When
        var result = SubstringSearchMethods.FindAllIndexesWithLINQ(input, search);

        // Then
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedIndexes, result);
    }

    [Test]
    public void Given_InputStringWithNoMatches_When_FindAllIndexesWithLINQCalled_Then_ReturnEmptyList()
    {
        // Given
        var input = "This is a test string.";
        var search = "ip";

        // When
        var result = SubstringSearchMethods.FindAllIndexesWithLINQ(input, search);

        // Then
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Given_SubstringBiggerThanInputString_When_FindAllIndexesWithLINQCalled_Then_ReturnEmptyList()
    {
        // Given
        var input = "abc";
        var search = "abcdef";

        // When
        var result = SubstringSearchMethods.FindAllIndexesWithLINQ(input, search);

        // Then
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }
}

