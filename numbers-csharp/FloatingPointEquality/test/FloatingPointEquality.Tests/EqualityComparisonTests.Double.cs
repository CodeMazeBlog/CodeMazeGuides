namespace FloatingPointEquality.Tests;

public partial class EqualityComparisonTests
{
    [Fact]
    public void
        GivenDoublesAndOutOfRangePrecision_WhenEqualityComparisonWithPrecisionIsCalled_ThenShouldThrowException()
    {
        const double a = 1.12345;
        const double b = 1.12344;

        var act1 = () => FloatingPointComparisons.EqualityUsingPrecision(a, b, 20);
        var act2 = () => FloatingPointComparisons.EqualityUsingPrecision(a, b, -1);

        act1.Should().Throw<IndexOutOfRangeException>();
        act2.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void GivenTwoDoubleNaNs_WhenEqualityComparisonWithPrecisionIsCalled_ThenShouldReturnFalse()
    {
        const double a = double.NaN;
        const double b = double.NaN;
        const int decimalPlaces = 1;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDoubleInfinityValues_WhenEqualityComparisonWithPrecisionIsCalled_ThenShouldReturnTrue()
    {
        const double a = double.PositiveInfinity;
        const double b = double.PositiveInfinity;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeDoubleInfinityValues_WhenEqualityComparisonWithPrecisionIsCalled_ThenShouldReturnFalse()
    {
        const double a = double.PositiveInfinity;
        const double b = double.NegativeInfinity;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualDoubles_WhenEqualityComparisonWithPrecisionIsCalled_ThenShouldReturnTrue()
    {
        const double a = 1.12345;
        const double b = 1.12344;
        const int decimalPlaces = 4;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualDoubles_WhenEqualityComparisonWithPrecisionIsCalledWithHigherPrecision_ThenShouldReturnFalse()
    {
        const double a = 1.12345;
        const double b = 1.12344;
        const int decimalPlaces = 5;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDifferentDoubles_WhenEqualityComparisonWithPrecisionIsCalled_ThenShouldReturnFalse()
    {
        const double a = 10.0;
        const double b = 20.0;
        const int decimalPlaces = 1;

        var result = FloatingPointComparisons.EqualityUsingPrecision(a, b, decimalPlaces);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDoubleNaNs_WhenEqualityComparisonWithToleranceIsCalled_ThenShouldReturnFalse()
    {
        const double a = double.NaN;
        const double b = double.NaN;
        const double tolerance = 1e-10;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDoubleInfinityValues_WhenEqualityComparisonWithToleranceIsCalled_ThenShouldReturnTrue()
    {
        const double a = double.PositiveInfinity;
        const double b = double.PositiveInfinity;
        const double tolerance = 1e-10;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeDoubleInfinityValues_WhenEqualityComparisonWithToleranceIsCalled_ThenShouldReturnFalse()
    {
        const double a = double.PositiveInfinity;
        const double b = double.NegativeInfinity;
        const double tolerance = 1e-10;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualDoubles_WhenEqualityComparisonWithToleranceIsCalled_ThenShouldReturnTrue()
    {
        const double a = 1.12345;
        const double b = 1.12344;
        const double tolerance = 1e-4;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualDoubles_WhenEqualityComparisonWithToleranceIsCalledWithHigherTolerance_ThenShouldReturnFalse()
    {
        const double a = 1.12345;
        const double b = 1.12344;
        const double tolerance = 1e-5;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDifferentDoubles_WhenEqualityComparisonWithToleranceIsCalled_ThenShouldReturnFalse()
    {
        const double a = 10.0;
        const double b = 20.0;
        const double tolerance = 1e-2;

        var result = FloatingPointComparisons.EqualityUsingTolerance(a, b, tolerance);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDoubleNaNs_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnFalse()
    {
        const double a = double.NaN;
        const double b = double.NaN;
        const long maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoDoubleInfinityValues_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnTrue()
    {
        const double a = double.PositiveInfinity;
        const double b = double.PositiveInfinity;
        const long maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenPositiveAndNegativeDoubleInfinityValues_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnFalse()
    {
        const double a = double.PositiveInfinity;
        const double b = double.NegativeInfinity;
        const long maxUlp = 10;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualDoubles_WhenEqualityComparisonUsingMaxUlpIsCalled_ThenShouldReturnTrue()
    {
        const double a = 1.12345;
        const double b = 1.1234500000000012;
        const long maxUlp = 5;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeTrue();
    }

    [Fact]
    public void
        GivenTwoAlmostEqualDoubles_WhenEqualityComparisonUsingMaxUlpIsCalledWithLowerMaxUlp_ThenShouldReturnFalse()
    {
        const double a = 1.12345;
        const double b = 1.1234500000000012;
        const long maxUlp = 4;

        var result = FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);

        result.Should().BeFalse();
    }

    [Fact]
    public void
        GivenTwoDoubles_WhenEqualityCompareUsingMaxUlpIsCalledWithZeroMaxUlp_ThenShouldThrowArgumentOutOfRangeException()
    {
        const double a = 1.12345;
        const double b = 1.1234500000000012;
        const long maxUlp = 0;

        var act = () => FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void
        GivenTwoDoubles_WhenEqualityCompareUsingMaxUlpIsCalledWithNegativeMaxUlp_ThenShouldThrowArgumentOutOfRangeException()
    {
        const double a = 1.12345;
        const double b = 1.1234500000000012;
        const long maxUlp = -1;

        var act = () => FloatingPointComparisons.EqualityUsingMaxUnitsInLastPlace(a, b, maxUlp);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}