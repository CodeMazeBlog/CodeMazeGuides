using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class AttributeIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AttributeIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Theory]
    [InlineData("/Customers")]
    [InlineData("/Customers/Index")]
    [InlineData("/Customers/Info/4")]
    [InlineData("/Customers/Order")]
    [InlineData("/Customers/Customer/Order")]
    [InlineData("/Special")]
    public async Task WhenMapControllersRun_ThenSuccess(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}