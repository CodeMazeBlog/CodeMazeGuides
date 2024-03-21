namespace SerilogBestPractices.Tests;

public class WeatherForecastEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task WhenGetWeatherForecastEndpointIsInvoked_ThenWeatherForecastIsReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/weatherforecast");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
