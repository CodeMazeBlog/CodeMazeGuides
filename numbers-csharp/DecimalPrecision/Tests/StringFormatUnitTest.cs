namespace TestProject1;

public class StringFormatUnitTest
{
    [Theory]
    [InlineData(123.456, "123.46")]
    [InlineData(8.6789, "8.68")]
    [InlineData(7.0, "7.00")]
    [InlineData(0.1234, "0.12")]
    [InlineData(-15.6789, "-15.68")]
    public void SetPrecisionUsingStringFormat_ShouldFormatCorrectly(decimal input, string expected)
    {
        // Act
        var result = StringFormat.SetPrecisionUsingStringFormat(input);

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
        var result = StringFormat.SetPrecisionUsingStringFormat(input, 2);

        // Assert
        Assert.Equal(expected, result);
    }
}