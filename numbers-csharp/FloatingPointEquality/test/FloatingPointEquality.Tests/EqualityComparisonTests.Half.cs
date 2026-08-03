namespace FloatingPointEquality.Tests;

public partial class EqualityComparisonTests
{
    [Fact]
    public void GivenHalfsAndOutOfRangePrecision_WhenEqualityUsingPrecisionIsCalled_ThenShouldThrowException()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.124;

        var act1 = () => FloatingPointComparisons.EqualityUsingPrecision(a, b, 20);
        var act2 = () => FloatingPointComparisons.EqualityUsingPrecision(a, b, -1);

        act1.Should().Throw<IndexOutOfRangeException>();
        act2.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void GivenTwoHalfNaNs_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnFalse()
    {
        var a = Half.NaN;
        var b = Half.NaN;
        const int decimalPlaces = 1;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoHalfInfinityValues_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnTrue()
    {
        var a = Half.PositiveInfinity;
        var b = Half.PositiveInfinity;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeHalfInfinityValues_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnFalse()
    {
        var a = Half.PositiveInfinity;
        var b = Half.NegativeInfinity;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualHalfs_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnTrue()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.124;
        const int decimalPlaces = 2;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqual_WhenEqualityUsingPrecisionIsCalledWithHigherPrecision_ThenShouldReturnFalse()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.124;
        const int decimalPlaces = 3;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDifferentHalfs_WhenEqualityUsingPrecisionIsCalled_ThenShouldReturnFalse()
    {
        var a = (Half) 10;
        var b = (Half) 20;
        const int decimalPlaces = 1;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoHalfNaNs_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnFalse()
    {
        var a = Half.NaN;
        var b = Half.NaN;
        var tolerance = (Half) 1e-2;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoHalfInfinityValues_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnTrue()
    {
        var a = Half.PositiveInfinity;
        var b = Half.PositiveInfinity;
        var tolerance = (Half) 1e-2;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeHalfInfinityValues_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnFalse()
    {
        var a = Half.PositiveInfinity;
        var b = Half.NegativeInfinity;
        var tolerance = (Half) 1e-2;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualHalfs_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnTrue()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.124;
        var tolerance = (Half) 1e-2;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualHalfs_WhenEqualityUsingToleranceIsCalledWithHigherPrecision_ThenShouldReturnFalse()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.124;
        var tolerance = (Half) 1e-4;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDifferentHalfs_WhenEqualityUsingToleranceIsCalled_ThenShouldReturnFalse()
    {
        var a = (Half) 10;
        var b = (Half) 20;
        var tolerance = (Half) 1e-2;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }


    [Fact]
    public void GivenTwoHalfNaNs_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnFalse()
    {
        var a = Half.NaN;
        var b = Half.NaN;
        const int maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoHalfInfinityValues_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnTrue()
    {
        var a = Half.PositiveInfinity;
        var b = Half.PositiveInfinity;
        const int maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeHalfInfinityValues_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnFalse()
    {
        var a = Half.PositiveInfinity;
        var b = Half.NegativeInfinity;
        const int maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualHalfs_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnTrue()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.1279;
        const int maxUlp = 5;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualHalfs_WhenEqualityComparisonUsingMaxUlpIsCalledWithLowerMaxUlp_ThenShouldReturnFalse()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.1279;
        const int maxUlp = 4;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoHalfs_WhenEqualityCompareUsingMaxUlpIsCalledWithZeroMaxUlp_ThenShouldThrowArgumentOutOfRangeException()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.124;
        const int maxUlp = 0;

        var act = () => FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void
        GivenTwoHalfs_WhenEqualityCompareUsingMaxUlpIsCalledWithNegativeMaxUlp_ThenShouldThrowArgumentOutOfRangeException()
    {
        var a = (Half) 1.123;
        var b = (Half) 1.124;
        const int maxUlp = -1;

        var act = () => FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}