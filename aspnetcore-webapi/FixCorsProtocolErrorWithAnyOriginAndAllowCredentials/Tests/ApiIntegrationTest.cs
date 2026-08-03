namespace Tests;

public class ApiIntegrationTest : IClassFixture<ApiApplicationFactory>
{
    private readonly HttpClient _client;

    public ApiIntegrationTest(ApiApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData("https://unknown.com")]
    [InlineData("https://another.com")]
    [InlineData("https://yet-one-more.com")]
    public async Task GivenApiDummyController_WhenBadEndpointIsCalledWithAnyOrigin_ThenAllowOriginAndAllowCredentialsIsNotReturned(string origin)
    {
        // Arrange
        const string url = "https://localhost:5001/api/dummy/bad";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Origin", origin);

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        Assert.False(response.Headers.Contains(HeaderNames.AccessControlAllowOrigin));
        Assert.False(response.Headers.Contains(HeaderNames.AccessControlAllowCredentials));
    }

    [Theory]
    [InlineData("https://unknown.com")]
    [InlineData("https://another.com")]
    [InlineData("https://yet-one-more.com")]
    [InlineData("*")]
    public async Task GivenApiDummyController_WhenGoodEndpointIsCalledWithAnyOrigin_ThenAllowOriginAndAllowCredentialsIsReturned(string origin)
    {
        // Arrange
        const string url = "https://localhost:5001/api/dummy/good";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Origin", origin);

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        Assert.True(response.Headers.Contains(HeaderNames.AccessControlAllowOrigin));
        Assert.Contains(origin, response.Headers.GetValues(HeaderNames.AccessControlAllowOrigin));
        Assert.True(response.Headers.Contains(HeaderNames.AccessControlAllowCredentials));
    }

    [Theory]
    [InlineData("https://allowed-origin.com")]
    [InlineData("https://another-allowed-origin.com")]
    public async Task GivenApiDummyController_WhenBestEndpointIsCalledWithAllowedOrigin_ThenAllowOriginAndAllowCredentialsIsReturned(
        string origin)
    {
        // Arrange
        const string url = "https://localhost:5001/api/dummy/best";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Origin", origin);

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        Assert.True(response.Headers.Contains(HeaderNames.AccessControlAllowOrigin));
        Assert.Contains(origin, response.Headers.GetValues(HeaderNames.AccessControlAllowOrigin));
        Assert.True(response.Headers.Contains(HeaderNames.AccessControlAllowCredentials));
    }

    [Theory]
    [InlineData("https://unknown.com")]
    [InlineData("https://another.com")]
    [InlineData("https://yet-one-more.com")]
    [InlineData("*")]
    public async Task
        GivenApiDummyController_WhenBestEndpointIsCalledWithUnknownOrigin_ThenAllowOriginAndAllowCredentialsIsNotReturned(
            string origin)
    {
        // Arrange
        const string url = "https://localhost:5001/api/dummy/best";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Origin", origin);

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        Assert.False(response.Headers.Contains(HeaderNames.AccessControlAllowOrigin));
        Assert.False(response.Headers.Contains(HeaderNames.AccessControlAllowCredentials));
    }
}