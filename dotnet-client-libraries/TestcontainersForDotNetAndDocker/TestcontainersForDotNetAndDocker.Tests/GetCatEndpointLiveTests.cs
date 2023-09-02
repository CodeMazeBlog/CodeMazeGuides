namespace TestcontainersForDotNetAndDocker.Tests;

public class GetCatEndpointLiveTests : IClassFixture<CatsApiApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public GetCatEndpointLiveTests(CatsApiApplicationFactory catsApiApplicationFactory)
    {
        _httpClient = catsApiApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task GivenCatExists_WhenGetCatEndpointIsInvoked_ThenOkIsReturned()
    {
        // Arrange
        var catRequest = new CreateCatRequest(
            Constants.Name, Constants.Age, Constants.Weight);
        var createCatResponse = await _httpClient.PostAsJsonAsync("CreateCat", catRequest);
        var catResponse = await createCatResponse.Content.ReadFromJsonAsync<CatResponse>();

        // Act
        var response = await _httpClient.GetAsync($"GetCat/{catResponse.Id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GivenCatDoesNotExists_WhenGetCatEndpointIsInvoked_ThenNotFoundIsReturned()
    {
        // Act
        var response = await _httpClient.GetAsync($"GetCat/{Guid.NewGuid()}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
