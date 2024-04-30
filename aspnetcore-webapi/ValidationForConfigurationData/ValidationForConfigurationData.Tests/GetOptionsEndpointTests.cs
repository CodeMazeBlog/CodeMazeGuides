namespace ValidationForConfigurationData.Tests;

public class GetOptionsEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task WhenGetOptionsEndpointIsInvoked_ThenOptionsAreReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/options");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}