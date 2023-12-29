using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Tests;

public class IExceptionHandlerUnitTest
{
    private readonly HttpClient _client;
    public IExceptionHandlerUnitTest()
    {
        var application = new WebApplicationFactory<Program>();
        _client = application.CreateClient();
    }

    [Theory]
    [InlineData("/books/1")]
    public async Task WhenGetByIdEndpointIsCalled_ThenReturnBookIfExists(string url)
    {
        var response = await _client.GetAsync(url);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/books/100")]
    public async Task WhenGetByIdIsCalled_ThenReturnBadRequestForNonexistentBook(string url)
    {
        var response = await _client.GetAsync(url);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task WhenGetAllBooksEndpointIsCalled_ThenReturnAllBooks()
    {
        var response = await _client.GetAsync("/books");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

}
