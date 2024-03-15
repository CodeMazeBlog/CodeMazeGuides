using RemoveWhitespaceCharactersFromString;

namespace RemoveWhitespaceCharactersFromStringTests;

public class RemoveWhitespaceCharactersFromStringTests
{
    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingRegexClass_ThenResultStringDoesNotContainWhitespace(string source,
        string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingStaticRegexClass(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingCachedRegex_ThenResultStringDoesNotContainWhitespace(string source,
        string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingCachedRegex(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingSourceGenRegex_ThenResultStringDoesNotContainWhitespace(
        string source, string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingSourceGenRegex(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingLinqWithStringConcat_ThenResultStringDoesNotContainWhitespace(
        string source, string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConcat(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingLinqWithStringConstruct_ThenResultStringDoesNotContainWhitespace(
        string source, string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConstruct(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingStringReplace_ThenResultStringDoesNotContainWhitespace(
        string source, string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingReplace(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingStringSplitJoin_ThenResultStringDoesNotContainWhitespaces(
        string source, string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingSplitJoin(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingStringBuilderForLoop_ThenResultStringDoesNotContainWhitespace(
        string source, string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingStringBuilder(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringsTestData))]
    public void GivenStringWithWhitespaces_WhenUsingArray_ThenResultStringDoesNotContainWhitespace(string source,
        string expected)
    {
        var result = RemoveWhitespaceMethods.RemoveWhitespacesUsingArray(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringTrimTestData))]
    public void
        GivenStringWithWhitespaces_WhenUsingStringTrim_ThenResultStringDoesNotContainLeadingOrTrailingWhitespace(
            string source, string expected)
    {
        var result = RemoveWhitespaceMethods.TrimWhitespacesUsingStringTrim(source);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(WhitespaceStringTrimTestData))]
    public void
        GivenStringWithWhitespaces_WhenUsingRegexTrim_ThenResultStringDoesNotContainLeadingOrTrailingWhitespace(
            string source, string expected)
    {
        var result = RemoveWhitespaceMethods.TrimWhitespacesUsingSourceGenRegex(source);

        Assert.Equal(expected, result);
    }
}