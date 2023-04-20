namespace IdentifyIfAStringIsANumber.Tests;

public class Tests
{
    [Theory]
    [InlineData("123")]
    [InlineData("444")]
    public void GivenAnIntegerNumbersAsString_WhenUsingIntTryParse_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.IntTryParse(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("1.2345")]
    [InlineData("2.4412")]
    public void GivenAnDecimalNumberAsString_WhenUsingIntTryParse_ThenReturnFalse(string value)
    {
        var result = StringIsANumberChecker.IntTryParse(value);

        Assert.False(result);
    }

    [Theory]
    [InlineData("9999999999")]
    public void GivenABigIntegerNumberAsString_WhenUsingIntTryParse_ThenReturnFalse(string value)
    {
        var result = StringIsANumberChecker.IntTryParse(value);

        Assert.False(result);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("444")]
    public void GivenAnIntegerNumbersAsString_WhenUsingCharIsDigit_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.UsingCharIsDigit(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("1.2345")]
    [InlineData("2.4412")]
    public void GivenAnDecimalNumberAsString_WhenUsingCharIsDigit_ThenReturnFalse(string value)
    {
        var result = StringIsANumberChecker.UsingCharIsDigit(value);

        Assert.False(result);
    }

    [Theory]
    [InlineData("9999999999")]
    public void GivenABigIntegerNumberAsString_WhenUsingCharIsDigit_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.UsingCharIsDigit(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("444")]
    public void GivenAnIntegerNumbersAsString_WhenUsingDoubleTryParse_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.DoubleTryParse(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("1.2345")]
    [InlineData("2.4412")]
    public void GivenAnDecimalNumberAsString_WhenUsingDoubleTryParse_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.DoubleTryParse(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("9999999999")]
    public void GivenABigIntegerNumberAsString_WhenUsingDoubleTryParse_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.DoubleTryParse(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("444")]
    public void GivenAnIntegerNumbersAsString_WhenUsingRegex_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.UsingRegex(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("1.2345")]
    [InlineData("2.4412")]
    public void GivenAnDecimalNumberAsString_WhenUsingRegex_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.UsingRegex(value);

        Assert.True(result);
    }

    [Theory]
    [InlineData("9999999999")]
    public void GivenABigIntegerNumberAsString_WhenUsingRegex_ThenReturnTrue(string value)
    {
        var result = StringIsANumberChecker.UsingRegex(value);

        Assert.True(result);
    }
}