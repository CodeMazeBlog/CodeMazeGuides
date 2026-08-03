using Microsoft.AspNetCore.Mvc.Testing;
using ModelStateValidation.Models;
using System.Net.Http.Json;
using Xunit;

namespace Tests;

public class BooksControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BooksControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async void GivenValidBookInput_WhenPostBooksEndpointIsCalled_Then200StatusCodeIsReturned()
    {
        // Given
        var client = _factory.CreateClient();

        var createBookInputModel = new CreateBookInputModel
        {
            Title = "Title",
            Description = "Book description",
            ISBN = "1234567899999"
        };

        // When
        var response = await client.PostAsJsonAsync("/books", createBookInputModel);

        // Then
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }


    [Fact]
    public async void GivenInvalidBookInput_WhenPostBooksEndpointIsCalled_Then422StatusCodeIsReturned()
    {
        // Given
        var client = _factory.CreateClient();

        var createBookInputModel = new CreateBookInputModel
        {
            Description = "Book description",
            ISBN = "123456789"
        };

        // When
        var response = await client.PostAsJsonAsync("/books", createBookInputModel);

        // Then
        Assert.Equal(System.Net.HttpStatusCode.UnprocessableEntity, response.StatusCode);
    }
}