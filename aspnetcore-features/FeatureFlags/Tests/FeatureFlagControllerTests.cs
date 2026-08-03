using FeatureFlags;
using FeatureFlags.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Tests;
public class FeatureFlagControllerTests
{
    private readonly Mock<IFeatureManager> _featureManager = new();
    private readonly FeatureFlagController _controller;

    public FeatureFlagControllerTests()
    {
        _controller = new FeatureFlagController(_featureManager.Object);
    }

    [Fact]
    public async Task GivenEndpointWithFeatureManager_WhenBooleanFilterIsEnabled_ThenOkIsReturned()
    {
        // Arrange
        _featureManager.Setup(f => f.IsEnabledAsync("BooleanFilter")).ReturnsAsync(true);

        // Act
        var forecast = await _controller.BooleanFilter();
        var okResult = forecast as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact]
    public async Task GivenEndpointWithFeatureManager_WhenBooleanFilterIsDisabled_ThenBadRequestIsReturned()
    {
        // Arrange
        _featureManager.Setup(f => f.IsEnabledAsync("BooleanFilter")).ReturnsAsync(false);

        // Act
        var forecast = await _controller.BooleanFilter();
        var badRequestResult = forecast as BadRequestObjectResult;

        // Assert
        Assert.NotNull(badRequestResult);
        Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
    }
}