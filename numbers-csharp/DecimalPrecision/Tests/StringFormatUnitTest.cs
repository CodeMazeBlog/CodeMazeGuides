using DecimalPrecision;

namespace TestProject1;

public class StringFormatUnitTest
{
    private readonly StringFormat _stringFormat = new StringFormat();

    [Theory]
    [InlineData(123.456, "123.46")]
    [InlineData(8.6789, "8.68")]
    [InlineData(7.0, "7.00")]
    [InlineData(0.1234, "0.12")]
    [InlineData(-15.6789, "-15.68")]
    public void SetPrecisionUsingStringFormat_ShouldFormatCorrectly(decimal input, string expected)
    {
        // Act
        string result = _stringFormat.SetPrecisionUsingStringFormat(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(123.456, "123.46")]
    [InlineData(8.6789, "8.68")]
    [InlineData(7.0, "7.00")]
    [InlineData(0.1234, "0.12")]
    [InlineData(-15.6789, "-15.68")]
    public void SetPrecisionUsingStringFormatAndGlobalScope_ShouldFormatCorrectly(decimal input, string expected)
    {
        // Act
        string result = _stringFormat.SetPrecisionUsingStringFormatAndGlobalScope(input);

        // Assert
        Assert.Equal(expected, result);
    }
}