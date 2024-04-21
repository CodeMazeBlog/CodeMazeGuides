namespace ValidationForConfigurationData.Tests;

public class GetSettingsEndpointTests(WebApplicationFactory<Program> factory)
: IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task WhenGetSettingsEndpointIsInvoked_ThenSettingsAreReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/settings");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}