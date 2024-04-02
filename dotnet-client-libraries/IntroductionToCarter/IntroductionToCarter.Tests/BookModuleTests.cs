using FluentAssertions;
using IntroductionToCarter.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace IntroductionToCarter.Tests;

public class BookModuleTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task WhenGetBooksEndpointIsInvoked_ThenAllBooksAreReturned()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync("/api/books");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task WhenGetBookEndpointIsInvoked_ThenBookIsReturned()
    {
        // Arrange
        var client = factory.CreateClient();
        var book = new CreateBookRequest("Title", "Author", "ISBN", 2024);

        var response = await client.PostAsJsonAsync("/api/books", book);
        var createdBook = JsonSerializer.Deserialize<BookResponse>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.GetAsync($"/api/books/{createdBook!.Id}");
        var returnedBook = JsonSerializer.Deserialize<BookResponse>(
            await result.Content.ReadAsStringAsync(), _options);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
        returnedBook.Should().NotBeNull();
        returnedBook!.Title.Should().Be(book.Title);
        returnedBook!.Author.Should().Be(book.Author);
        returnedBook!.ISBN.Should().Be(book.ISBN);
        returnedBook!.Year.Should().Be(book.Year);
    }

    [Fact]
    public async Task WhenAddBookEndpointIsInvoked_ThenBookIsAdded()
    {
        // Arrange
        var client = factory.CreateClient();
        var book = new CreateBookRequest("Title", "Author", "ISBN", 2024);

        // Act
        var response = await client.PostAsJsonAsync("/api/books", book);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task WhenUpdateBookEndpointIsInvoked_ThenBookIsUpdated()
    {
        // Arrange
        var client = factory.CreateClient();
        var book = new CreateBookRequest("Title", "Author", "ISBN", 2024);

        var response = await client.PostAsJsonAsync("/api/books", book);
        var createdBook = JsonSerializer.Deserialize<BookResponse>(
            await response.Content.ReadAsStringAsync(),
            _options);

        var bookForUpdate = new UpdateBookRequest("New title", "New author", "Wew ISBN", 2025);

        // Act
        await client.PutAsJsonAsync($"/api/books/{createdBook!.Id}", bookForUpdate);

        // Assert
        var updatedBookResponse = await client.GetAsync($"/api/books/{createdBook!.Id}");
        var updatedBook = JsonSerializer.Deserialize<BookResponse>(
            await updatedBookResponse.Content.ReadAsStringAsync(), _options);

        updatedBookResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        updatedBook!.Should().NotBeNull();
        updatedBook!.Title.Should().Be(bookForUpdate.Title);
        updatedBook!.Author.Should().Be(bookForUpdate.Author);
        updatedBook!.ISBN.Should().Be(bookForUpdate.ISBN);
        updatedBook!.Year.Should().Be(bookForUpdate.Year);
    }

    [Fact]
    public async Task WhenDeleteBookEndpointIsInvoked_ThenBookIsDeleted()
    {
        // Arrange
        var client = factory.CreateClient();
        var book = new CreateBookRequest("Title", "Author", "ISBN", 2024);

        var response = await client.PostAsJsonAsync("/api/books", book);
        var createdBook = JsonSerializer.Deserialize<BookResponse>(
            await response.Content.ReadAsStringAsync(),
            _options);

        // Act
        var result = await client.DeleteAsync($"/api/books/{createdBook!.Id}");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}