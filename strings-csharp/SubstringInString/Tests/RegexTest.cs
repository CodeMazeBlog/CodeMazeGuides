using System.Text.RegularExpressions;

[TestFixture]
public class RegexTest
{
    [Test]
    public void Given_InputStringAndSearchString_When_FindAllIndexesWithRegexCalled_Then_ReturnListOfIndexes()
    {
        // Given
        var input = "Lorem ipsum dolor sit amet, consectetur adipiscing elip. Duis quis nisip eget sem vehipula accumsan.";
        var search = "ip";
        var regex = new Regex(search);
        var expectedIndexes = new List<int> { 6, 42, 53, 70, 85 };

        // When
        var result = SubstringSearchMethods.FindAllIndexesWithRegex(input, regex);

        // Then
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedIndexes, result);
    }

    [Test]
    public void Given_InputStringWithNoMatches_When_FindAllIndexesWithRegexCalled_Then_ReturnEmptyList()
    {
        // Given
        var input = "This is a test string.";
        var search = "ip";
        var regex = new Regex(search); // Compile the regex pattern into a Regex object

        // When
        var result = SubstringSearchMethods.FindAllIndexesWithRegex(input, regex);

        // Then
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void Given_SubstringBiggerThanInputString_When_FindAllIndexesWithRegexCalled_Then_ReturnEmptyList()
    {
        // Given
        var input = "abc";
        var search = "abcdef";
        var regex = new Regex(search); // Compile the regex pattern into a Regex object

        // When
        var result = SubstringSearchMethods.FindAllIndexesWithRegex(input, regex);

        // Then
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }
}
