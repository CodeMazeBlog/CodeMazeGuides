namespace Api.Tests;

public class UpdateCatEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task WhenUpdateCatEndpointIsInvoked_ThenCatIsUpdated()
    {
        // Arrange
        var client = factory.CreateClient();
        var cat = new CatForCreationDto
        {
            Name = "Test",
            Breed = "Test",
            DateOfBirth = DateTime.UtcNow,
        };
        var createdCatResponse = await client.PostAsJsonAsync("/cats", cat);
        var createdCat = JsonSerializer.Deserialize<CatDto>(
            await createdCatResponse.Content.ReadAsStringAsync(),
            _options);
        var catForUpdate = new CatForUpdateDto
        {
            Name = "Foo",
            Breed = "Bar",
            DateOfBirth = createdCat!.DateOfBirth
        };

        // Act
        await client.PutAsJsonAsync($"/cats/{createdCat!.Id}", catForUpdate);

        // Assert
        var updatedCatResponse = await client.GetAsync($"/cats/{createdCat!.Id}");
        var updatedCat = JsonSerializer.Deserialize<CatDto>(
            await updatedCatResponse.Content.ReadAsStringAsync(), _options);

        updatedCatResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        updatedCat!.Should().NotBeNull();
        updatedCat!.Name.Should().Be(catForUpdate.Name);
        updatedCat!.Breed.Should().Be(catForUpdate.Breed);
    }
}
