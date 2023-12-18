using FluentAssertions;

namespace TestProject1;

public class RoundingFunctionUnitTest
{
    [Theory]
    [InlineData(12.3456, 12.35)]
    [InlineData(8.6789, 8.68)]
    [InlineData(7.0, 7.00)]
    [InlineData(0.1234, 0.12)]
    [InlineData(-15.6789, -15.68)]
    public void GetDecimalRoundValueUsingDecimalRound_ShouldRoundCorrectly(decimal input, decimal expected)
    {
        input.Round(2).Should().BeApproximately(expected, 0.001M);
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
        input.Truncate().Should().BeApproximately(expected, 0.001M);
    }

    [Theory]
    [InlineData(12.3456, 12)]
    [InlineData(8.6789, 8)]
    [InlineData(7.0, 7)]
    [InlineData(0.1234, 0)]
    [InlineData(-15.6789, -16)]
    [InlineData(0.0, 0)]
    [InlineData(-0.1234, -1)]
    public void GetDecimalRoundValueUsingDecimalFloor_ShouldTruncateCorrectly(decimal input, decimal expected)
    {
        input.Floor().Should().BeApproximately(expected, 0.001M);
    }

    [Theory]
    [InlineData(12.3456, 13)]
    [InlineData(8.6789, 9)]
    [InlineData(7.0, 7)]
    [InlineData(0.1234, 1)]
    [InlineData(-15.6789, -15)]
    [InlineData(0.0, 0)]
    [InlineData(-0.1234, 0)]
    public void GetDecimalRoundValueUsingDecimalCeiling_ShouldTruncateCorrectly(decimal input, decimal expected)
    {
        input.Ceiling().Should().BeApproximately(expected, 0.001M);
    }
}