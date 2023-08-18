namespace TestcontainersForDotNetAndDocker.Tests;

public class UpdateCatEndpointLiveTests : IClassFixture<CatsApiApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public UpdateCatEndpointLiveTests(CatsApiApplicationFactory catsApiApplicationFactory)
    {
        _httpClient = catsApiApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task GivenCatExists_WhenUpdateCatEndpointIsInvoked_ThenOkIsReturned()
    {
        // Arrange
        var createCatRequest = new CreateCatRequest(
            Constants.Name, Constants.Age, Constants.Weight);
        var createCatResponse = await _httpClient.PostAsJsonAsync("CreateCat", createCatRequest);
        var catResponse = await createCatResponse.Content.ReadFromJsonAsync<CatResponse>();
        var updateCatRequest = new UpdateCatRequest(
            catResponse.Id,
            catResponse.Name,
            catResponse.Age,
            catResponse.Weight);


        // Act
        var response = await _httpClient.PutAsJsonAsync("UpdateCat", updateCatRequest);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GivenCatDoesNotExists_WhenUpdateCatEndpointIsInvoked_ThenNotFoundIsReturned()
    {
        // Arrange
        var catRequest = new UpdateCatRequest(
            Guid.NewGuid(), Constants.Name, Constants.Age, Constants.Weight);

        // Act
        var response = await _httpClient.PutAsJsonAsync("UpdateCat", catRequest);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
