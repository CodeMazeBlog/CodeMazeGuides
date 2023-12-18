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
        input.ToString(format).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(123.456, 2, "123.46")]
    [InlineData(8.6789, 2, "8.68")]
    [InlineData(7.0, 2, "7.00")]
    [InlineData(0.1234, 3, "0.123")]
    [InlineData(-15.4789, 3, "-15.479")]
    [InlineData(-15.4789, 0, "-15")]
    public void SetPrecisionUsingStringFormatAndGlobalScope_ShouldFormatCorrectly(decimal input, int decimalPlaces,
        string expected)
    {
        input.ToStringXDecimalPlaces(decimalPlaces).Should().Be(expected);
    }
}