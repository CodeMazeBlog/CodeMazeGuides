namespace MinimalAPIDemo.Tests;
public class CustomHeaderTests
{
    private readonly HttpClient _client;
    public CustomHeaderTests()
    {
        WebApplicationFactory<Program> application = new();
        _client = application.CreateClient();
    }

    [Fact]
    public async Task GivenGetRequestWithCustomHeader_WhenValidHeader_ThenReturnsOk()
    {
        _client.DefaultRequestHeaders.Add("X-Custom-Header", "secret-key");
        var response = await _client.GetAsync("/api/sample");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenGetRequestWithCustomHeader_WhenInvalidHeader_ThenReturnsUnauthorized()
    {
        _client.DefaultRequestHeaders.Add("X-Custom-Header", "invalid-key");
        var response = await _client.GetAsync("/api/sample");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GivenPostRequestWithCustomHeader_WhenValidHeader_ThenReturnsOk()
    {
        _client.DefaultRequestHeaders.Add("X-Custom-Header", "secret-key");
        var response = await _client.PostAsync("/api/sample", null);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GivenPostRequestWithCustomHeader_WhenEmptyHeader_ThenReturnsUnauthorized()
    {
        _client.DefaultRequestHeaders.Add("X-Custom-Header", "");
        var response = await _client.PostAsync("/api/sample", null);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task GivenPostRequestWithCustomHeader_WhenNoHeader_ThenReturnsUnauthorized()
    {
        var response = await _client.PostAsync("/api/sample", null);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}