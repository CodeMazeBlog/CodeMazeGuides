public class AreaOfShapeTest
{
    [Fact]
    public void When_RectangleAreaCalled_Then_CalculatesCorrectly()
    {
        // Arrange
        double length = 5;
        double width = 10;
        // Act
        double result = Area.RectangleArea(length, width);
        // Assert
        Assert.Equal(50, result);
    }

    [Fact]
    public void When_CircleAreaCalled_Then_CalculatesCorrectly()
    {
        // Arrange
        double radius = 7;
        // Act
        double result = Area.CircleArea(radius);
        // Assert
        Assert.Equal(Math.PI * Math.Pow(radius, 2), result, 8); // Accept a small deviation due to floating-point precision
    }

    [Fact]
    public void When_TriangleAreaCalled_Then_CalculatesCorrectly()
    {
        // Arrange
        double a = 3;
        double b = 4;
        double c = 5;
        // Act
        double result = Area.TriangleArea(a, b, c);
        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void When_DisplayResultCalled_Then_WritesToConsole()
    {
        // Arrange
        using (var consoleOutput = new ConsoleOutput())
        {
            // Act
            Area.DisplayResult("rectangle", 50);
            // Assert
            Assert.Equal($"The area of the rectangle is: 50{Environment.NewLine}", consoleOutput.GetOutput());
        }
    }

}
