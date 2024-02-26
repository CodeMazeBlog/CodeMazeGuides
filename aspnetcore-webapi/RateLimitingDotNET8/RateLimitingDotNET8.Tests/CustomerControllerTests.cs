using Microsoft.AspNetCore.Mvc.Testing;

namespace RateLimitingDotNET8.Tests;
public class CustomerControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CustomerControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _client.DefaultRequestHeaders.UserAgent.ParseAdd("fakeUserAgent");
        _client.DefaultRequestHeaders.Add("X-Test-RemoteIP", "127.0.0.1");
    }

    [Theory]
    [InlineData("/Customer/Index")]
    [InlineData("/Customer/Details")]
    [InlineData("/Customer/GetById")]
    [InlineData("/Customer/Get")]
    [InlineData("/Customer/SpecialOffer")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        
        // Act
        var response = await _client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }
}
