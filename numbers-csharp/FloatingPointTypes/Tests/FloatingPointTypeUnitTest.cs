using FloatingPointTypes;

namespace a;

public class FloatingPointTypeUnitTest
{
    private readonly FloatingPointArithmetic _floatingPointArithmetic;

    public FloatingPointTypeUnitTest()
    {
        _floatingPointArithmetic = new FloatingPointArithmetic();
    }

    [Theory]
    [InlineData(0.1f, 0.5f, 10)]
    [InlineData(0.21f, 0.155f, 20)]
    public void WhenResultsOfFloatComputationAreCompared_ThenReturnFalse(float firstValue, float secondValue,
        int factor)
    {
        var result = _floatingPointArithmetic.FloatSumAndMultiplication(firstValue, secondValue, factor);

        Assert.False(result);
    }

    [Theory]
    [InlineData(0.2D, 1.5D, 10)]
    [InlineData(0.21D, 1.51D, 11)]
    public void WhenResultsOfDoubleComputationAreCompared_ThenReturnFalse(double firstValue, double secondValue,
        int factor)
    {
        var result = _floatingPointArithmetic.DoubleSumAndMultiplication(firstValue, secondValue, factor);

        Assert.False(result);
    }

    [Theory]
    [InlineData(0.2, 1.5, 10)]
    [InlineData(0.345, 1.678, 15)]
    public void WhenResultsOfDecimalComputationAreCompared_ThenReturnTrue(decimal firstValue, decimal secondValue,
        int factor)
    {
        var result = _floatingPointArithmetic.DecimalSumAndMultiplication(firstValue, secondValue, factor);

        Assert.True(result);
    }
}