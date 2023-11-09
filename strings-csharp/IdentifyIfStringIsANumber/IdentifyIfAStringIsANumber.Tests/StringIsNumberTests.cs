namespace IdentifyIfAStringIsANumber.Tests;

public class StringIsNumberTests
{
    [Theory]
    [InlineData("123", true)]
    [InlineData("1.2345", false)]
    [InlineData("9999999999", false)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    [InlineData("١٢٣", false)]
    public void GivenAString_WhenUsingIntTryParseMethod_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.IntTryParse(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("1.2345", false)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    [InlineData("١٢٣", false)]
    public void GivenAString_WhenUsingCharIsDigit_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.UsingCharIsDigit(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("1.2345", true)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    [InlineData("١٢٣", false)]
    public void GivenAString_WhenUsingDoubleTryParse_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.DoubleTryParse(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("1.2345", true)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    [InlineData("١٢٣", false)]
    public void GivenAString_WhenUsingRegex_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.UsingRegex(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("1.2345", true)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    [InlineData("١٢٣", false)]
    public void GivenAString_WhenUsingCompiledRegex_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.UsingCompiledRegex(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("1.2345", false)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    [InlineData("١٢٣", false)]
    public void GivenAString_WhenUsingCharIsDigitWithForeach_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.UsingCharIsDigitWithForeach(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("1.2345", false)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    [InlineData("١٢٣", false)]
    public void GivenAString_WhenUsingCharIsBetween09_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.UsingCharIsBetween09(value);

        Assert.Equal(expectedResult, result);
    }
}