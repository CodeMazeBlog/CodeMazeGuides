namespace TestProject1;

public class RoundingFunctionUnitTest
{
    [Theory]
    [InlineData(12.3456, 12.35)]
    [InlineData(8.6789, 8.68)]
    [InlineData(7.0, 7.00)]
    [InlineData(0.1234, 0.12)]
    [InlineData(-15.6789, -15.68)]
    public void GetDecimalRoundValueUsingMathRound_ShouldRoundCorrectly(decimal input, decimal expected)
    {
        // Act
        var result = RoundingFunction.GetDecimalRoundValueUsingMathRound(input);

        // Assert
        Assert.Equal(expected, result, 2);
    }

    [Theory]
    [InlineData(12.3456, 12.35)]
    [InlineData(8.6789, 8.68)]
    [InlineData(7.0, 7.00)]
    [InlineData(0.1234, 0.12)]
    [InlineData(-15.6789, -15.68)]
    public void GetDecimalRoundValueUsingDecimalRound_ShouldRoundCorrectly(decimal input, decimal expected)
    {
        // Act
        var result = RoundingFunction.GetDecimalRoundValueUsingDecimalRound(input);

        // Assert
        Assert.Equal(expected, result, 2);
    }
    
    [Theory]
    [InlineData(123.456789, 123.46)] 
    [InlineData(123.455, 123.46)]
    [InlineData(123.454, 123.45)]
    public void GetDecimalRoundValue_WhenMidPointRoundingToEven(decimal input, decimal expected)
    {
        // Act
        var result = RoundingFunction.GetDecimalRoundValuesUsingMidPointRoundingModelToEven(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(123.456789, 123.46)]
    [InlineData(123.455, 123.46)] 
    [InlineData(123.454, 123.45)] 
    public void GetDecimalRoundValue_WhenMidPointRoundingAwayFromZero(decimal input, decimal expected)
    {
        // Act
        var result = RoundingFunction.GetDecimalRoundValuesUsingMidPointRoundingModelAwayFromZero(input);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(123.456789, 123.45)]
    [InlineData(123.455, 123.45)]  
    [InlineData(123.454, 123.45)] 
    public void GetDecimalRoundValue_WhenMidPointRoundingToZero(decimal input, decimal expected)
    {
        // Act
        var result = RoundingFunction.GetDecimalRoundValuesUsingMidPointRoundingModelToZero(input);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(12.3456, 12)]
    [InlineData(8.6789, 8)]
    [InlineData(7.0, 7)]
    [InlineData(0.1234, 0)]
    [InlineData(-15.6789, -15)]
    [InlineData(0.0, 0)]
    [InlineData(-0.1234, 0)]
    public void GetDecimalRoundValueUsingDecimalTruncate_ShouldTruncateCorrectly(decimal input, decimal expected)
    {
        // Act
        var result = RoundingFunction.GetDecimalRoundValueUsingDecimalTruncate(input);

        // Assert
        Assert.Equal(expected, result, 2);
    }
}