using StandardAndCustomFormatStrings;

namespace StandardAndCustomFormatStringsTests;

public class StandardFormatStringsTests
{
    [Theory]
    [InlineData(1234.56, "1,234.56")]
    public void GivenANumber_WhenCurrencyFormat_ReturnsCurrency(double input, string expected)
    {
        string result = StandardFormatStrings.CurrencyFormat(input);

        Assert.Contains(expected, result);
    }

    [Theory]
    [InlineData(1234.56, "1 234,56 €")]
    public void GivenANumber_WhenEuroCurrency_ReturnsCurrencyInEuro(double input, string expected)
    {
        string result = StandardFormatStrings.EuroCurrency(input);

        Assert.Contains(expected, result);
    }

    [Theory]
    [InlineData(1234, "1234")]
    public void GivenANumber_WhenDecimalFormat_ReturnsDecimalNumber(int input, string expected)
    {
        string result = StandardFormatStrings.DecimalFormat(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1234.5678, "1234.57")]
    public void GivenANumber_WhenFixedPointFormat_ReturnsRoundedNumber(double input, string expected)
    {
        string result = StandardFormatStrings.FixedPointFormat(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(123, "00123")]
    public void GivenANumber_WhenDecimalPrecision_ReturnsFiveDigitNumber(int input, string expected)
    {
        string result = StandardFormatStrings.DecimalPrecision(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1234.5678, "1234.57")]
    public void GivenANumber_WhenFloatingPointPrecision_ReturnsRoundedFloatingNumber(double input, string expected)
    {
        string result = StandardFormatStrings.FloatingPointPrecision(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0.1234, "%")]
    public void GivenANumber_WhenPercentage_ReturnsPercentage(double input, string expected)
    {
        string result = StandardFormatStrings.Percentage(input);

        Assert.Contains(expected, result);
    }
}