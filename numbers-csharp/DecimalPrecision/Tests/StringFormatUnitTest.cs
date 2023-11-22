namespace TestProject1;

public class StringFormatUnitTest
{
    [Theory]
    [InlineData(123.456789, "0.00", "123.46")]
    [InlineData(123.456789, "0.0000", "123.4568")]
    [InlineData(9876.54321, "0", "9877")]
    [InlineData(-123.456789, "0.00", "-123.46")]
    [InlineData(0.123456789, "0.00", "0.12")]
    [InlineData(0, "0.00", "0.00")]
    public void FormatDecimalWithPrecision_ReturnsExpected(decimal input, string format, string expectedResult)
    {
        // Act
        var result = StringFormat.FormatDecimalWithPrecision(input, format);

        // Assert
        Assert.Equal(expectedResult, result);
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
        var result = StringFormat.SetPrecisionUsingStringFormatInfo(input, 2);

        // Assert
        Assert.Equal(expected, result);
    }
}