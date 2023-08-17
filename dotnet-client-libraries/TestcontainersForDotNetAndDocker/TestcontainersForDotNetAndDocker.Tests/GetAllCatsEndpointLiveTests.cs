namespace TestcontainersForDotNetAndDocker.Tests;

public class GetAllCatsEndpointLiveTests : IClassFixture<CatsApiApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public GetAllCatsEndpointLiveTests(CatsApiApplicationFactory catsApiFactory)
    {
        _httpClient = catsApiFactory.CreateClient();
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
