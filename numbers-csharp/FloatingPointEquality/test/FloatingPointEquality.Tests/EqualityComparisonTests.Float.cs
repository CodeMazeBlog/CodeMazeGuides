namespace FloatingPointEquality.Tests;

public partial class EqualityComparisonTests
{
    [Fact]
    public void GivenFloatsAndOutOfRangePrecision_WhenEqualityUsingPrecisionIsCalled_ThenShouldThrowException()
    {
        const float a = 1.12345f;
        const float b = 1.12344f;

        var act1 = () => FloatingPointComparisons.EqualityUsingPrecision(a, b, 20);
        var act2 = () => FloatingPointComparisons.EqualityUsingPrecision(a, b, -1);

        act1.Should().Throw<IndexOutOfRangeException>();
        act2.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void GivenTwoFloatNaNs_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnFalse()
    {
        const float a = float.NaN;
        const float b = float.NaN;
        const int decimalPlaces = 1;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoFloatInfinityValues_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnTrue()
    {
        const float a = float.PositiveInfinity;
        const float b = float.PositiveInfinity;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeFloatInfinityValues_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnFalse()
    {
        const float a = float.PositiveInfinity;
        const float b = float.NegativeInfinity;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualFloats_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnTrue()
    {
        const float a = 1.12345f;
        const float b = 1.12344f;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualFloats_WhenEqualityUsingPrecisionIsCalledWithHigherPrecision_ThenShouldReturnFalse()
    {
        const float a = 1.12345f;
        const float b = 1.12344f;
        const int decimalPlaces = 5;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDifferentFloats_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnFalse()
    {
        const float a = 10f;
        const float b = 20f;
        const int decimalPlaces = 1;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoFloatNaNs_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnFalse()
    {
        const float a = float.NaN;
        const float b = float.NaN;
        const float tolerance = 1e-5f;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoFloatInfinityValues_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnTrue()
    {
        const float a = float.PositiveInfinity;
        const float b = float.PositiveInfinity;
        const float tolerance = 1e-5f;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeFloatInfinityValues_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnFalse()
    {
        const float a = float.PositiveInfinity;
        const float b = float.NegativeInfinity;
        const float tolerance = 1e-5f;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoEqualFloatsWithDifferentTolerance_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnTrue()
    {
        const float a = 1.12345f;
        const float b = 1.12344f;
        const float tolerance = 1e-4f;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoEqualFloatsWithDifferentTolerance_WhenEqualityUsingToleranceIsCalledWithHigherTolerance_ThenShouldReturnFalse()
    {
        const float a = 1.12345f;
        const float b = 1.12344f;
        const float tolerance = 1e-5f;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDifferentFloats_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnFalse()
    {
        const float a = 10f;
        const float b = 20f;
        const float tolerance = 1e-2f;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoFloatNaNs_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnFalse()
    {
        const float a = float.NaN;
        const float b = float.NaN;
        const int maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoFloatInfinityValues_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnTrue()
    {
        const float a = float.PositiveInfinity;
        const float b = float.PositiveInfinity;
        const int maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeFloatInfinityValues_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnFalse()
    {
        const float a = float.PositiveInfinity;
        const float b = float.NegativeInfinity;
        const int maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualFloats_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnTrue()
    {
        const float a = 1.12345004f;
        const float b = 1.12345064f;
        const int maxUlp = 5;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualFloatWith_WhenEqualityComparisonUsingMaxUlpIsCalledWithLowerMaxUlp_ThenShouldReturnFalse()
    {
        const float a = 1.12345004f;
        const float b = 1.12345064f;
        const int maxUlp = 4;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoFloats_WhenEqualityCompareUsingMaxUlpIsCalledWithZeroMaxUlp_ThenShouldThrowArgumentOutOfRangeException()
    {
        const float a = 1.12345004f;
        const float b = 1.12345064f;
        const int maxUlp = 0;

        var act = () => FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void
        GivenTwoFloats_WhenEqualityCompareUsingMaxUlpIsCalledWithNegativeMaxUlp_ThenShouldThrowArgumentOutOfRangeException()
    {
        const float a = 1.12345004f;
        const float b = 1.12345064f;
        const int maxUlp = -1;

        var act = () => FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}