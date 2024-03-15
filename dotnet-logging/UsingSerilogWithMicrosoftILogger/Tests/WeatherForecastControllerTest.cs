using Microsoft.Extensions.Logging;
using Moq;
using UsingSerilogWithMicrosoftILogger.Controllers;
using Xunit;

namespace Tests;

public class WeatherForecastControllerTest
{
    [Fact]
    public void WhenLoggingInformationWithAMessage_ThenMessageShouldBeShownInConsole()
    {
        // Arrange
        var _loggerMock = new Mock<ILogger<WeatherForecastController>>();

        // Act
        var response = new WeatherForecastController(_loggerMock.Object).Get();

        // Assert
        _loggerMock.Verify(logger => logger.Log(LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Processing GetWeatherForecast...")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
    }
}

