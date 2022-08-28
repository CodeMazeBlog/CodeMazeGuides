using FeatureFlags;
using FeatureFlags.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Tests;
public class WeatherForecastControllerTests
{
    private readonly Mock<IFeatureManager> _featureManager = new();
    private readonly WeatherForecastController _controller;

    public WeatherForecastControllerTests()
    {
        _controller = new WeatherForecastController(_featureManager.Object);
    }

    [Fact]
    public async Task GivenEndpointWithFeatureManager_WhenShowForecastIsEnabled_ThenForecastIsReturned()
    {
        // Arrange
        _featureManager.Setup(f => f.IsEnabledAsync("ShowForecast")).ReturnsAsync(true);

        // Act
        var forecast = await _controller.Get();
        var okResult = forecast as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.IsType<WeatherForecast[]>(okResult.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact]
    public async Task GivenEndpointWithFeatureManager_WhenShowForecastIsDisabled_ThenBadRequestIsReturned()
    {
        // Arrange
        _featureManager.Setup(f => f.IsEnabledAsync("ShowForecast")).ReturnsAsync(false);

        // Act
        var forecast = await _controller.Get();
        var badRequestResult = forecast as BadRequestObjectResult;

        // Assert
        Assert.NotNull(badRequestResult);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
}