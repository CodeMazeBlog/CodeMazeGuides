using HowToSolveTRequestCannotBeTypeParameter.Controllers;
using Xunit;

namespace HowToSolveTRequestCannotBeTypeParameterTests;

public class WeatherForecastControllerTests
{
    [Fact]
    public void WhenGet_ReturnsWeatherForecasts()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.Equal(5, result.Count());
    }
}
