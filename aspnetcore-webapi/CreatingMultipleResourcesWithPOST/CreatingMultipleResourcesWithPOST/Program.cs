using CreatingMultipleResorcesWithPOST.Infrastructure;
using CreatingMultipleResorcesWithPOST.Models;
using CreatingMultipleResorcesWithPOST.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("api"));
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/api/books", (BookRequest bookRequests, IBookService bookService) =>
{
    var createdBook = bookService.CreateBook(bookRequests);

    return Results.Created($"/api/books/{createdBook.Id}", createdBook);
});

app.MapPost("/api/books/batch", (BookRequest[] bookRequests, IBookService bookService) =>
{
    var createdBooks = bookService.CreateBooks(bookRequests);
 
    return createdBooks.Select(x => (object)x);
});

app.MapGet("/api/books", (IBookService bookService) =>
{
    var books = bookService.GetBooks();

    return books;
});

app.Run();