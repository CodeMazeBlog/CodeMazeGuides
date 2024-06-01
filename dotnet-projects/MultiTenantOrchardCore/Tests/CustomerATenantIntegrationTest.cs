using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class CustomerATenantIntegrationTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/customer-a")]
    public async Task WhenCustomerAHome_ThenSuccess(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }
    
    [Theory]
    [InlineData("/customer-a/Email")]
    public async Task WhenCustomerAEmailModule_ThenSuccess(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        
        Assert.Equal("Welcome to Email module", body);
    }
    
    [Theory]
    [InlineData("/customer-a/Sms")]
    public async Task WhenCustomerASmsModule_ThenStatusCodeNotFound(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);
        
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}