using ParallelProgrammingDifferences.Controllers;
using Xunit;

namespace ParallelProgrammingDifferencesTests;

public class WeatherForecastControllerTests
{
    [Fact]
    public async Task WhenGetWeatherForecastParallelForEachAsync_ThenShouldReturnMergedResults()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = await controller.GetWeatherForecastParallelForEachAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(15, result.Count());
    }

    [Fact]
    public async Task WhenGetWeatherForecastTaskWhenAll_ThenShouldReturnMergedResults()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = await controller.GetWeatherForecastWhenAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(15, result.Count());
    }
}