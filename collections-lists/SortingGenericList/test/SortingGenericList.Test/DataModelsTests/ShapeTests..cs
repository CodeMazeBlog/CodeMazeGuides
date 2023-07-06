namespace SortingGenericList.Test.DataModelsTests;

public class ShapeTests
{
    [Fact]
    public void CompareToTest_GivenOtherShape_ReturnsExpectedGreaterThanComparisonResult()
    {
        var mockShape1 = UnitTestSetupHelpers.CreateShapeMock(5, 4);
        var mockShape2 = UnitTestSetupHelpers.CreateShapeMock(4, 5);

        var actualComparisonResult = mockShape1.CompareTo(mockShape2);

        actualComparisonResult.Should().BePositive();
    }

    [Fact]
    public void CompareToTest_GivenOtherShape_ReturnsExpectedLessThanComparisonResult()
    {
        var mockShape1 = UnitTestSetupHelpers.CreateShapeMock(4, 5);
        var mockShape2 = UnitTestSetupHelpers.CreateShapeMock(5, 4);

        var actualComparisonResult = mockShape1.CompareTo(mockShape2);

        actualComparisonResult.Should().BeNegative();
    }

    [Fact]
    public void CompareToTest_GivenOtherShape_ReturnsExpectedEqualComparisonResult()
    {
        var mockShape1 = UnitTestSetupHelpers.CreateShapeMock(4, 5);
        var mockShape2 = UnitTestSetupHelpers.CreateShapeMock(4, 5);

        var actualComparisonResult = mockShape1.CompareTo(mockShape2);

        actualComparisonResult.Should().Be(0);
    }

    [Fact]
    public void EqualsTest_GivenOtherShape_ReturnsExpectedEqualityResult()
    {
        var mockShape1 = UnitTestSetupHelpers.CreateShapeMock(4, 5);
        var mockShape2 = UnitTestSetupHelpers.CreateShapeMock(4, 5);

        mockShape1.Equals(mockShape2).Should().BeTrue();
    }
}