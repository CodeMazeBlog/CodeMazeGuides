using System.Net.Http.Json;
using TestcontainersForDotNetAndDocker.Contracts.Requests;

namespace TestcontainersForDotNetAndDocker.Tests;

public class CreateCatEndpointTests : IClassFixture<CatsApiFactory>
{
    private readonly HttpClient _httpClient;

    public CreateCatEndpointTests(CatsApiFactory catsApiFactory)
    {
        _httpClient = catsApiFactory.CreateClient();
    }

    [Fact]
    public async Task WhenCreateCatEndpointIsInvoked_ThenCatIsAddedToTheDatabase()
    {
        var catRequest = new CreateCatRequest("Baklava", 1, 4);

        var response = await _httpClient.PostAsJsonAsync("CreateCat", catRequest);
    }
}