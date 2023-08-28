namespace TestcontainersForDotNetAndDocker.Tests;

public class DeleteCatEndpointLiveTests : IClassFixture<CatsApiApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public DeleteCatEndpointLiveTests(CatsApiApplicationFactory catsApiApplicationFactory)
    {
        _httpClient = catsApiApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task GivenCatExists_WhenDeleteCatEndpointIsInvoked_ThenOkIsReturned()
    {
        // Arrange
        var catRequest = new CreateCatRequest(
            Constants.Name, Constants.Age, Constants.Weight);
        var createCatResponse = await _httpClient.PostAsJsonAsync("CreateCat", catRequest);
        var catResponse = await createCatResponse.Content.ReadFromJsonAsync<CatResponse>();

        // Act
        var response = await _httpClient.DeleteAsync($"DeleteCat/{catResponse.Id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GivenCatDoesNotExists_WhenDeleteCatEndpointIsInvoked_ThenNotFoundIsReturned()
    {
        // Act
        var response = await _httpClient.DeleteAsync($"DeleteCat/{Guid.NewGuid()}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
