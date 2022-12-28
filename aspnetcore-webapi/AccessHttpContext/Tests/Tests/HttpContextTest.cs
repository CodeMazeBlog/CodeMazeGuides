using System.Net.Http.Headers;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace Tests;

public class HttpContextTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public HttpContextTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("application/json")]
    [InlineData("content/type")]
    public async Task WhenGettingHomeController_ThenReturnContentType(string contentType)
    {
        // arrange
        var client = _factory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "controllers/example")
        {
            Content = new StringContent(string.Empty)
        };
        request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

        // act
        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        // assert
        Assert.Equal(contentType, result);
    }

    [Fact]
    public async Task WhenGettingMinimalAPI_ThenReturnHelloWorld()
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var result = await client.GetStringAsync("minimal");

        // assert
        Assert.Equal("Hello from minimal API", result);
    }

    [Fact]
    public async Task WhenGettingCustomMiddleware_ThenReturnPath()
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var result = await client.GetStringAsync("middleware");

        // assert
        Assert.Equal("/middleware", result);
    }

    [Fact]
    public async Task WhenGettingRazorPage_ThenReturnPath()
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var result = await client.GetStringAsync("razors/example");

        // assert
        Assert.Contains("Path: /razors/example", result);
    }

    [Fact]
    public async Task WhenGettingService_ThenReturnHelloWorld()
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var result = await client.GetStringAsync("service");

        // assert
        Assert.Equal("Hello from custom service", result);
    }
}