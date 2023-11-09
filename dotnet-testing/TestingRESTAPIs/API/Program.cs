using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var books = new List<Book>();

void InitializeBooks() => books = Enumerable.Range(1, 5)
    .Select(index => new Book(index, $"Awesome book #{index}"))
    .ToList();

InitializeBooks();

app.MapGet("/books", () =>
{
    return Results.Ok(books);
});

app.MapPost("/books", (Book book) =>
{
    books.Add(book);

    return Results.Created($"/books/{book.BookId}", book);
});

app.MapPut("/books", (Book book) =>
{
    books.RemoveAll(book => book.BookId == book.BookId);
    books.Add(book);

    return Results.NoContent();
});

app.MapDelete("/books/{bookId}", (int bookId) =>
{
    books.RemoveAll(book => book.BookId == bookId);

    return Results.NoContent();
});

app.MapDelete("/state", () =>
{
    InitializeBooks();

    return Results.NoContent();
});

app.MapGet("/admin", ([FromHeader(Name = "X-Api-Key")] string apiKey) =>
{
    if (apiKey == "SuperSecretApiKey")
    {
        return Results.Ok("Hi admin!");
    }

    return Results.Unauthorized();
});

app.Run();

internal record Book(int BookId, string Title);