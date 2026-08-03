using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Tests;

public class CustomAuthorizeAttributeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CustomAuthorizeAttributeTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/WeatherForecast/WithCustomAuthorizeAttribute")]
    [InlineData("/WeatherForecast/WithCustomAuthorizationPolicy")]
    public async Task WhenSessionIdHeaderNotPassed_ThenReturnsUnauthorized(string endpoint)
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var response = await client.GetAsync(endpoint);

        // assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Theory]
    [InlineData("/WeatherForecast/WithCustomAuthorizeAttribute")]
    [InlineData("/WeatherForecast/WithCustomAuthorizationPolicy")]
    public async Task WhenSessionIdHeaderPassed_ThenReturnsSuccess(string endpoint)
    {
        // arrange
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Add("X-Session-Id", new Guid().ToString());

        // act
        var response = await client.GetAsync(endpoint);

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
