namespace SortingGenericList.Test.DataModelsTests;

public class SquareTests
{
    private const double Tolerance = 1E-10;

    [Fact]
    public void Square_Area_Is_Correctly_Calculated()
    {
        const double side = 5;
        const double expectedArea = side * side;

        var square = new Square(side);

        square.Area.Should().BeApproximately(expectedArea, Tolerance);
    }

    [Fact]
    public void Square_Circumference_Is_Correctly_Calculated()
    {
        const double side = 5;
        const double expectedCircumference = 4 * side;

        var square = new Square(side);

        square.Circumference.Should().BeApproximately(expectedCircumference, Tolerance);
    }
}