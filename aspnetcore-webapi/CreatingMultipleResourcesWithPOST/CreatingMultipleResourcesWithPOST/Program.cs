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

app.MapPost("/api/books/batch", (BookRequest[] bookRequests, IBookService bookService, HttpResponse response) =>
{
    var createdBooks = bookService.CreateBooks(bookRequests);

    response.StatusCode = StatusCodes.Status207MultiStatus;
 
    return createdBooks.Select(x => (object)x);
});

app.Run();