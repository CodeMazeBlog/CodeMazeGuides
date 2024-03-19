using HstsExample.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests;

public class WeatherForecastControllerTests
{
    [Fact]
    public void WeatherForecastController_WhenGetCalled_ReturnResults()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<WeatherForecastController>>();
        var controller = new WeatherForecastController(mockLogger.Object);

        // Act
        var result = controller.Get();

        // Assert
        Assert.NotNull(result);
    }
}