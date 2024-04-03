namespace Api.Tests;

public class DeleteCatEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task WhenDeleteCatEndpointIsInvoked_ThenCatIsDeleted()
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
        var catDto = JsonSerializer.Deserialize<CatDto>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.DeleteAsync($"/cats/{catDto!.Id}");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
