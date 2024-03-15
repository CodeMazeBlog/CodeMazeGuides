namespace Api.Tests;

public class AddCatEndpointTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task WhenAddCatEndpointIsInvoked_ThenCatIsAdded()
    {
        // Arrange
        var client = factory.CreateClient();
        var cat = new CatForCreationDto
        {
            Name = "Test",
            Breed = "Test",
            DateOfBirth = DateTime.UtcNow,
        };

        // Act
        var response = await client.PostAsJsonAsync("/cats", cat);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}
