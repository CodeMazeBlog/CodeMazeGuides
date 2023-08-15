namespace TestcontainersForDotNetAndDocker.Tests;

public class GetCatEndpointTests : IClassFixture<CatsApiFactory>
{
    private readonly HttpClient _httpClient;

    public GetCatEndpointTests(CatsApiFactory catsApiFactory)
    {
        _httpClient = catsApiFactory.CreateClient();
    }

    [Fact]
    public void WhenGetCatEndpointIsInvoked_ThenCatIsReturned()
    {

    }
}
