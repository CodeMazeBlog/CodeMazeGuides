namespace AspireDistributedApp.ApiService.Tests;

public class WeatherForecastEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task WhenWeatherForecastEndpointIsCalled_ThenSuccessStatusCodeIsReturned()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/weatherforecast");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}