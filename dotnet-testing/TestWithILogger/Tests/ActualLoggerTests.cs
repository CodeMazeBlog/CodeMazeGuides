using API.Controllers;
using Microsoft.Extensions.Logging;

namespace Tests;

public class ActualLoggerTests
{
    private readonly WeatherForecastController _forecastController;

    public ActualLoggerTests()
    {
        using var loggerFactory = LoggerFactory.Create(c => c.AddConsole());
        var logger = loggerFactory.CreateLogger<WeatherForecastController>();
        _forecastController = new WeatherForecastController(logger);
    }

    [Fact]
    public void WhenGettingForecastInfo_ReturnsData()
    {
        var response = _forecastController.GetForecastInfo();
        Assert.Equal(5, response.Count());
    }

    [Fact]
    public void WhenGettingForecastDebug_ReturnsData()
    {
        var response = _forecastController.GetForecastDebug();
        Assert.Equal(2, response.Count());
    }

    [Fact]
    public void WhenGettingForecastWarn_ReturnsData()
    {
        var response = _forecastController.GetForecastWarning();
        Assert.Equal(3, response.Count());
    }

    [Fact]
    public void WhenGettingForecastError_ReturnsData()
    {
        var response = _forecastController.GetForecastError();
        Assert.Equal(4, response.Count());
    }
}