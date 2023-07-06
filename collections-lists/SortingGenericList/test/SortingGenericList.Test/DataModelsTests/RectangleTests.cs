namespace SortingGenericList.Test.DataModelsTests;

public class RectangleTests
{
    private const double Tolerance = 1E-10;

    [Fact]
    public void Rectangle_Area_Is_Correctly_Calculated()
    {
        const double length = 5;
        const double width = 10;
        const double expectedArea = length * width;

        var rectangle = new Rectangle(length, width);

        rectangle.Area.Should().BeApproximately(expectedArea, Tolerance);
    }

    [Fact]
    public void Rectangle_Circumference_Is_Correctly_Calculated()
    {
        const double length = 5;
        const double width = 10;
        const double expectedCircumference = 2 * length + 2 * width;

        var rectangle = new Rectangle(length, width);

        rectangle.Circumference.Should().BeApproximately(expectedCircumference, Tolerance);
    }
}