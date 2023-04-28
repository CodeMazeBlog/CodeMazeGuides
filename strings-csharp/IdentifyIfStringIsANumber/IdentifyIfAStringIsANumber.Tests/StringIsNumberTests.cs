namespace IdentifyIfAStringIsANumber.Tests;

public class StringIsNumberTests
{
    [Theory]
    [InlineData("123", true)]
    [InlineData("444", true)]
    [InlineData("1.2345", false)]
    [InlineData("2.4412", false)]
    [InlineData("9999999999", false)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    public void GivenAString_WhenUsingIntTryParseMethod_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.IntTryParse(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("444", true)]
    [InlineData("1.2345", false)]
    [InlineData("2.4412", false)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    public void GivenAString_WhenUsingCharIsDigit_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.UsingCharIsDigit(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("444", true)]
    [InlineData("1.2345", true)]
    [InlineData("2.4412", true)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    public void GivenAString_WhenUsingDoubleTryParse_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.DoubleTryParse(value);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("444", true)]
    [InlineData("1.2345", true)]
    [InlineData("2.4412", true)]
    [InlineData("9999999999", true)]
    [InlineData("abc", false)]
    [InlineData("414aa", false)]
    public void GivenAString_WhenUsingRegex_ThenTryToParseIt(string value, bool expectedResult)
    {
        var result = StringIsANumberChecker.UsingRegex(value);

        Assert.Equal(expectedResult, result);
    }
}