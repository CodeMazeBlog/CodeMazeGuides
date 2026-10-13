namespace Tests;

public class CorsIntegrationTest : IClassFixture<ApiApplicationFactory>
{
    private const string ClientOrigin = "https://localhost:5011";
    private const string OtherClientOrigin = "https://localhost:5021";

    private readonly HttpClient _client;

    public CorsIntegrationTest(ApiApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData("/weatherforecast")]
    [InlineData("/minimal/weatherforecast")]
    public async Task GivenAllowedOrigin_WhenGetIsSent_ThenAllowOriginHeaderEchoesTheOrigin(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add(HeaderNames.Origin, ClientOrigin);

        var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        Assert.Equal(ClientOrigin, Assert.Single(response.Headers.GetValues(HeaderNames.AccessControlAllowOrigin)));
    }

    [Theory]
    [InlineData("/weatherforecast", "https://unknown.com")]
    [InlineData("/weatherforecast", OtherClientOrigin)]
    [InlineData("/minimal/weatherforecast", "https://unknown.com")]
    public async Task GivenDisallowedOrigin_WhenGetIsSent_ThenNoAllowOriginHeaderIsReturned(string url, string origin)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add(HeaderNames.Origin, origin);

        var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        Assert.False(response.Headers.Contains(HeaderNames.AccessControlAllowOrigin));
    }

    [Fact]
    public async Task GivenAllowedOrigin_WhenPreflightIsSent_ThenAllowMethodsHeaderListsGet()
    {
        var request = new HttpRequestMessage(HttpMethod.Options, "/weatherforecast");
        request.Headers.Add(HeaderNames.Origin, ClientOrigin);
        request.Headers.Add(HeaderNames.AccessControlRequestMethod, "GET");

        var response = await _client.SendAsync(request);

        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        Assert.Equal(ClientOrigin, Assert.Single(response.Headers.GetValues(HeaderNames.AccessControlAllowOrigin)));
        Assert.Equal("GET", Assert.Single(response.Headers.GetValues(HeaderNames.AccessControlAllowMethods)));
    }

    [Fact]
    public async Task GivenAnotherPolicyOrigin_WhenGetIsSent_ThenPaginationHeaderIsExposed()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/weatherforecast/anotherPolicyExample");
        request.Headers.Add(HeaderNames.Origin, OtherClientOrigin);

        var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        Assert.Equal(OtherClientOrigin, Assert.Single(response.Headers.GetValues(HeaderNames.AccessControlAllowOrigin)));
        Assert.Equal("X-Pagination", Assert.Single(response.Headers.GetValues(HeaderNames.AccessControlExposeHeaders)));
    }
}
