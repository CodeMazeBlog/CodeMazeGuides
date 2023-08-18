namespace TestcontainersForDotNetAndDocker.Tests;

public class CreateCatEndpointLiveTests : IClassFixture<CatsApiApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public CreateCatEndpointLiveTests(CatsApiApplicationFactory catsApiApplicationFactory)
    {
        _httpClient = catsApiApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task GivenCatDoesNotExist_WhenCreateCatEndpointIsInvoked_ThenCreatedIsReturned()
    {
        // Arrange
        var catRequest = new CreateCatRequest(
            Constants.Name, Constants.Age, Constants.Weight);

        // Act
        var response = await _httpClient.PostAsJsonAsync("CreateCat", catRequest);

        // Assert
        var catResponse = await response.Content.ReadFromJsonAsync<CatResponse>();
        catResponse.Should().NotBeNull().And.BeEquivalentTo(catRequest);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Headers.Location.Should().Be($"http://localhost/GetCat/{catResponse.Id}");
    }

    [Fact]
    public async Task GivenCatExist_WhenCreateCatEndpointIsInvoked_ThenBadRequestIsReturned()
    {
        // Arrange
        var catRequest = new CreateCatRequest(
            Constants.Name, Constants.Age, Constants.Weight);

        // Act
        var response = await _httpClient.PostAsJsonAsync("CreateCat", catRequest);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}