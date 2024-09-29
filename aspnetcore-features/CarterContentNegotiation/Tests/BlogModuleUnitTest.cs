using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;

namespace Tests;

public class BlogModuleUnitTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public BlogModuleUnitTest(WebApplicationFactory<Program> factory) => _client = factory.CreateClient();

    [Fact]
    public async Task GivenAJsonAcceptHeader_WhenCallingGetBlogs_ThenEndpointShouldReturnJson()
    {
        // Arrange
        var contentType = "application/json";
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

        // Act
        var response = await _client.GetAsync("/blogs");

        // Assert
        response.EnsureSuccessStatusCode(); // Verifies that the status code is 2xx
        Assert.StartsWith(contentType, response.Content.Headers.ContentType.ToString());

        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("\"title\":\"Building .NET Minimal API's\"", content); // Verifying content returned
    }

    [Fact]
    public async Task GivenAXmlAcceptHeader_WhenCallingGetBlogs_ThenEndpointShouldReturnXml()
    {
        // Arrange
        var contentType = "application/xml";

        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

        // Act
        var response = await _client.GetAsync("/blogs");

        // Assert
        response.EnsureSuccessStatusCode(); // Verifies that the status code is 2xx
        Assert.Equal(contentType, response.Content.Headers.ContentType.ToString());

        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("<Blog>", content); // Verifying content in XML format
    }
}