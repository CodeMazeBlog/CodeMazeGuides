namespace InjectDbContextIntoIHostedService.Tests;

public class CatsApiEndpointTests(CatsApiApplicationFactory factory) : IClassFixture<CatsApiApplicationFactory>
{
    [Fact]
    public async Task WhenCatsEndpointIsCalled_ThenSuccessStatusCodeIsReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/cats");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var content = await response.Content.ReadAsStringAsync();
        var cats = JsonSerializer.Deserialize<List<Cat>>(
            content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        cats!.Count.Should().Be(50);
    }
}
