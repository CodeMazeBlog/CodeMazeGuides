namespace SortingGenericList.Test;

public class ShapeCircumferenceComparerTests
{
    private readonly ShapeCircumferenceComparer _comparer = new();


    [Fact]
    public void Compare_ShouldReturnZero_WhenBothShapesAreNull()
    {
        _comparer.Compare(null, null).Should().Be(0);
    }

    [Fact]
    public void Compare_ShouldReturnMinusOne_WhenFirstShapeIsNull()
    {
        var shape = UnitTestSetupHelpers.CreateShapeMock(7, 5);

        _comparer.Compare(null, shape).Should().Be(-1);
    }

    [Fact]
    public void Compare_ShouldReturnOne_WhenSecondShapeIsNull()
    {
        var shape = UnitTestSetupHelpers.CreateShapeMock(7, 5);

        _comparer.Compare(shape, null).Should().Be(1);
    }

    [Fact]
    public void Compare_ShouldReturnZero_WhenBothShapesHaveSameCircumferenceAndArea()
    {
        var shape1 = UnitTestSetupHelpers.CreateShapeMock(7, 5);
        var shape2 = UnitTestSetupHelpers.CreateShapeMock(7, 5);

        _comparer.Compare(shape1, shape2).Should().Be(0);
    }

    [Fact]
    public void Compare_ShouldReturnPositive_WhenFirstShapeHasGreaterCircumference()
    {
        var shape1 = UnitTestSetupHelpers.CreateShapeMock(5, 7);
        var shape2 = UnitTestSetupHelpers.CreateShapeMock(7, 5);

        _comparer.Compare(shape1, shape2).Should().BePositive();
    }

    [Fact]
    public void Compare_ShouldReturnNegative_WhenSecondShapeHasGreaterCircumference()
    {
        var shape1 = UnitTestSetupHelpers.CreateShapeMock(7, 5);
        var shape2 = UnitTestSetupHelpers.CreateShapeMock(5, 7);

        _comparer.Compare(shape1, shape2).Should().BeNegative();
    }

    [Fact]
    public void Compare_ShouldCompareArea_WhenCircumferenceIsEqual()
    {
        var shape1 = UnitTestSetupHelpers.CreateShapeMock(7, 5);
        var shape2 = UnitTestSetupHelpers.CreateShapeMock(5, 5);

        _comparer.Compare(shape1, shape2).Should().BePositive();
        _comparer.Compare(shape2, shape1).Should().BeNegative();
    }
}