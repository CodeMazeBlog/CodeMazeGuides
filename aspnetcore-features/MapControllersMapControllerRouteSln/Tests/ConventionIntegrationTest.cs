using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class ConventionIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ConventionIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Theory]
    [InlineData("/")]
    [InlineData("/Home")]
    [InlineData("/Home/Index")]
    public async Task WhenMapControllerRouteRun_ThenSuccess(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/html; charset=utf-8", 
            response.Content.Headers.ContentType.ToString());
    }
}