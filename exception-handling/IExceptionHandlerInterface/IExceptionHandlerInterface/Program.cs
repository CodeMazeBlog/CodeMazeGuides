using IExceptionHandlerInterface.Middleware;
using IExceptionHandlerInterface.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILibraryService, LibraryService>();

builder.Services.AddExceptionHandler<ExceptionHandlingMiddleware>();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapGet("/books", async context =>
{
    var libraryService = context
    .RequestServices
    .GetRequiredService<ILibraryService>();

    var allBooks = libraryService.GetAllBooks();
    await context.Response.WriteAsJsonAsync(allBooks);
});

app.MapGet("/books/get-by-author", () =>
{
    throw new NotImplementedException();
});

app.MapGet("/books/{id}", async context =>
{
    var id = int.Parse(context.Request.RouteValues["id"].ToString());
    var libraryService = context
    .RequestServices
    .GetRequiredService<ILibraryService>();

    var book = libraryService.GetById(id);

    if (book != null)
    {
        await context.Response.WriteAsJsonAsync(book);
    }
    else
    {
        throw new BadHttpRequestException(
            $"Book with Id {id} not found.", StatusCodes.Status400BadRequest);
    }
});

app.Run();

public partial class Program { }