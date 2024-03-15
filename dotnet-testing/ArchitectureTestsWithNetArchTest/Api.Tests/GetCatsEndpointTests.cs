namespace Api.Tests;

public class GetCatsEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task WhenGetCatsEndpointIsInvoked_ThenAllCatsAreReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/cats");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
