using API.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests;

public class MockLoggerTests
{
    private readonly WeatherForecastController _forecastController;
    private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;

    public MockLoggerTests()
    {
        _mockLogger = new Mock<ILogger<WeatherForecastController>>();
        _forecastController = new WeatherForecastController(_mockLogger.Object);
    }

    [Fact]
    public void WhenGettingForecastInfo_ReturnsData()
    {
        var response = _forecastController.GetForecastInfo();
        Assert.Equal(5, response.Count());

        _mockLogger.Verify(l => 
            l.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Info")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Fact]
    public void WhenGettingForecastDebug_ReturnsData()
    {
        var response = _forecastController.GetForecastDebug();
        Assert.Equal(2, response.Count());

        _mockLogger.Verify(l => 
            l.Log(
                LogLevel.Debug,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Debug")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Fact]
    public void WhenGettingForecastWarn_ReturnsData()
    {
        var response = _forecastController.GetForecastWarning();
        Assert.Equal(3, response.Count());

        _mockLogger.Verify(l => 
            l.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Warning")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }

    [Fact]
    public void WhenGettingForecastError_ReturnsData()
    {
        var response = _forecastController.GetForecastError();
        Assert.Equal(4, response.Count());

        _mockLogger.Verify(l => 
            l.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Error")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }
}