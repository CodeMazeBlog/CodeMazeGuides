using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class DefaultTenantIntegrationTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/")]
    public async Task WhenDefaultTenant_ThenSuccess(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }
}