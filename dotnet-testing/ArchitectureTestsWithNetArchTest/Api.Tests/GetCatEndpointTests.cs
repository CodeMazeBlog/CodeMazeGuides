namespace Api.Tests;

public class GetCatEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task WhenGetCatEndpointIsInvoked_ThenCatIsReturned()
    {
        // Arrange
        var client = factory.CreateClient();
        var cat = new CatForCreationDto
        {
            Name = "Test",
            Breed = "Test",
            DateOfBirth = DateTime.UtcNow,
        };
        var response = await client.PostAsJsonAsync("/cats", cat);
        var createdCat = JsonSerializer.Deserialize<CatDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.GetAsync($"/cats/{createdCat!.Id}");

        // Assert
        var returnedCat = JsonSerializer.Deserialize<CatDto>(
            await result.Content.ReadAsStringAsync(), _options);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedCat.Should().NotBeNull();
    }
}
