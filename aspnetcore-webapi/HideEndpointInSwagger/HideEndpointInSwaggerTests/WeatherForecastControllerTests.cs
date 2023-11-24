using HideEndpointInSwagger.Controllers;
using Xunit;

namespace HideEndpointInSwaggerTests;

public class WeatherForecastControllerTests
{

    private readonly WeatherForecastController _weatherForecastController = new();

    [Fact]
    public void WhenGet_ThenReturnFiveWeatherForecasts()
    {
        // Act
        var result = _weatherForecastController.Get();

        // Assert
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void WhenGetMethodOne_ThenReturnFiveWeatherForecasts()
    {
        // Act
        var result = _weatherForecastController.GetMethodOne();

        // Assert
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void WhenGetMethodTwo_ThenReturnFiveWeatherForecasts()
    {
        // Act
        var result = _weatherForecastController.GetMethodTwo();

        // Assert
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void WhenGetMethodThree_ThenReturnFiveWeatherForecasts()
    {
        // Act
        var result = _weatherForecastController.GetMethodThree();

        // Assert
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void WhenGetMethodFour_ThenReturnFiveWeatherForecasts()
    {
        // Act
        var result = _weatherForecastController.GetMethodFour();

        // Assert
        Assert.Equal(5, result.Count());
    }
}