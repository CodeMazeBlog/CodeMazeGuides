namespace TestcontainersForDotNetAndDocker.Tests;

public class GetAllCatsEndpointLiveTests : IClassFixture<CatsApiApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public GetAllCatsEndpointLiveTests(CatsApiApplicationFactory catsApiApplicationFactory)
    {
        _httpClient = catsApiApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task WhenGetAllIsInvoked_ThenOkIsReturned()
    {
        // Arrange
        var catRequest = new CreateCatRequest(
            Constants.Name, Constants.Age, Constants.Weight);
        await _httpClient.PostAsJsonAsync("CreateCat", catRequest);

        // Act
        var response = await _httpClient.GetAsync("GetAllCats");
        var catsResponse = await response.Content.ReadFromJsonAsync<GetAllCatsResponse>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        catsResponse.Cats.Should().NotBeEmpty();
    }
}
