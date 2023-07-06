namespace SortingGenericList.Test.DataModelsTests;

public class CircleTests
{
    private const double Tolerance = 1E-10;

    [Fact]
    public void TestCircleConstructor_PositiveRadius_CalculatesArea()
    {
        const double radius = 5.0;
        const double expectedArea = Math.PI * radius * radius;

        var circle = new Circle(radius);

        circle.Area.Should().BeApproximately(expectedArea, Tolerance);
    }

    [Fact]
    public void TestCircleConstructor_PositiveRadius_CalculatesCircumference()
    {
        const double radius = 5;
        const double expectedCircumference = Math.PI * 2 * radius;

        var circle = new Circle(radius);

        circle.Circumference.Should().BeApproximately(expectedCircumference, Tolerance);
    }

    [Fact]
    public void TestCircleConstructor_ZeroRadius_CalculatesAreaCircumference()
    {
        const double radius = 0;
        var circle = new Circle(radius);

        circle.Area.Should().BeApproximately(0.0, Tolerance);
        circle.Circumference.Should().Be(0);
    }

    [Fact]
    public void TestCircleConstructor_NegativeRadius_ThrowsException()
    {
        const double radius = -1;

        this.Invoking(_ => new Circle(radius)).Should().Throw<ArgumentException>();
    }
}