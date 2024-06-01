using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class CustomerBTenantIntegrationTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/customer-b")]
    public async Task WhenCustomerAHome_ThenSuccess(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }
    
    [Theory]
    [InlineData("/customer-b/Email")]
    public async Task WhenCustomerAEmailModule_ThenSuccess(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        
        Assert.Equal("Welcome to Email module", body);
    }
    
    [Theory]
    [InlineData("/customer-b/Sms")]
    public async Task WhenCustomerASmsModule_ThenSuccess(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);
        
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        
        Assert.Equal("Welcome to SMS module", body);;
    }
}