namespace StringTruncationInCSharpTests;

public class StringTruncationTests
{
    private const string OriginalString = "This is a long string.";
    private const int MaxLength = 10;
    private const int MaxLengthLessThanZero = -10;
    private static readonly string ExpectedTruncatedString = OriginalString[..MaxLength];

    [Fact]
    public void WhenTruncatingAString_ThenUseSubstringMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseSubstringMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, OriginalString.Length);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseSubstringMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, OriginalString.Length + 10);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void GivenAZeroLength_WhenTruncatingAString_ThenUseSubstringMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, 0);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseSubstringMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, MaxLengthLessThanZero);

        Assert.Equal(string.Empty, truncatedString);
    }


    [Fact]
    public void WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, OriginalString.Length);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, OriginalString.Length + 10);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void GivenAZeroLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, 0);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void
        GivenANonPositiveLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, MaxLengthLessThanZero);

        Assert.Equal(string.Empty, truncatedString);
    }


    [Fact]
    public void WhenTruncatingAString_ThenUseRegularExpressionsMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, OriginalString.Length);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, OriginalString.Length + 10);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void GivenAZeroLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, 0);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, MaxLengthLessThanZero);

        Assert.Equal(string.Empty, truncatedString);
    }


    [Fact]
    public void WhenTruncatingAString_ThenUseRemoveMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithRemove(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }

    [Fact]
    public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseRemoveMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithRemove(OriginalString, OriginalString.Length);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseRemoveMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithRemove(OriginalString, OriginalString.Length + 10);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void GivenAZeroLength_WhenTruncatingAString_ThenUseRemoveMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithRemove(OriginalString, 0);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseRemoveMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithRemove(OriginalString, MaxLengthLessThanZero);

        Assert.Equal(string.Empty, truncatedString);
    }


    [Fact]
    public void WhenTruncatingAString_ThenUseLINQMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }

    [Fact]
    public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseLINQMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, OriginalString.Length);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseLINQMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, OriginalString.Length + 10);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void GivenAZeroLength_WhenTruncatingAString_ThenUseLINQMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, 0);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseLINQMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, MaxLengthLessThanZero);

        Assert.Equal(string.Empty, truncatedString);
    }


    [Fact]
    public void WhenTruncatingAString_ThenUseSpanToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithSpan(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }

    [Fact]
    public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseSpanMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithSpan(OriginalString, OriginalString.Length);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void
        GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseSpanMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithSpan(OriginalString, OriginalString.Length + 10);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void GivenAZeroLength_WhenTruncatingAString_ThenUseSpanMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithSpan(OriginalString, 0);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseSpanMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithSpan(OriginalString, MaxLengthLessThanZero);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void GivenAMultiLineString_WhenTruncatingAString_ThenUseRegularExpressionsMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithRegularExpressions("First line\nSecond line", 5);

        Assert.Equal("First", truncatedString);
    }

    [Fact]
    public void GivenATrailingNewLine_WhenTruncatingAString_ThenUseRegularExpressionsMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithRegularExpressions("Hello world\n", 5);

        Assert.Equal("Hello", truncatedString);
    }


    [Fact]
    public void WhenTruncatingAString_ThenUseTextElementsMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithTextElements(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }

    [Fact]
    public void GivenAZeroLength_WhenTruncatingAString_ThenUseTextElementsMethodAndReturnAnEmptyString()
    {
        var truncatedString = StringHelper.TruncateWithTextElements(OriginalString, 0);

        Assert.Equal(string.Empty, truncatedString);
    }

    [Fact]
    public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseTextElementsMethodWithoutTruncatingTheString()
    {
        var truncatedString = StringHelper.TruncateWithTextElements(OriginalString, OriginalString.Length + 10);

        Assert.Equal(OriginalString, truncatedString);
    }

    [Fact]
    public void GivenAnEmojiAtTheCut_WhenTruncatingWithSubstring_ThenTheResultEndsWithAHalfSurrogatePair()
    {
        var truncatedString = StringHelper.TruncateWithSubstring("Thumbs up \U0001F44D", 11);

        Assert.True(char.IsHighSurrogate(truncatedString[^1]));
    }

    [Fact]
    public void GivenAnEmojiAtTheCut_WhenTruncatingWithTextElements_ThenTheWholeEmojiIsDropped()
    {
        var truncatedString = StringHelper.TruncateWithTextElements("Thumbs up \U0001F44D", 11);

        Assert.Equal("Thumbs up ", truncatedString);
    }

    [Fact]
    public void GivenAJoinedEmojiAtTheCut_WhenTruncatingWithTextElements_ThenTheWholeEmojiIsDropped()
    {
        var truncatedString = StringHelper.TruncateWithTextElements("Family \U0001F468\u200D\U0001F469\u200D\U0001F467", 12);

        Assert.Equal("Family ", truncatedString);
    }

    [Fact]
    public void GivenAnEmojiAtTheCut_WhenTruncatingWithSurrogateCheck_ThenTheWholeEmojiIsDropped()
    {
        var truncatedString = StringHelper.TruncateWithSurrogateCheck("Thumbs up \U0001F44D", 11);

        Assert.Equal("Thumbs up ", truncatedString);
    }

    [Fact]
    public void WhenTruncatingAString_ThenUseSurrogateCheckMethodToTruncateTheString()
    {
        var truncatedString = StringHelper.TruncateWithSurrogateCheck(OriginalString, MaxLength);

        Assert.Equal(ExpectedTruncatedString, truncatedString);
    }
}