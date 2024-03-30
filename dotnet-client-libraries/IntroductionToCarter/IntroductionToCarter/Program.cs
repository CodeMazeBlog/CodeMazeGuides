using IntroductionToCarter.Contracts;
using IntroductionToCarter.Data;
using IntroductionToCarter.Services;
using IntroductionToCarter.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<BooksDbContext>(options =>
	options.UseInMemoryDatabase("Books"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/books", async (IBookService service) =>
{
	var books = await service.GetAllAsync();

	return Results.Ok(books);
})
.WithOpenApi();

app.MapGet("/books/{id:guid}", async (Guid id, IBookService service) =>
{
	var book = await service.GetByIdAsync(id);

	return Results.Ok(book);
})
.WithOpenApi();

app.MapPost("/books", async (CreateBookRequest request, IBookService service) =>
{
	var book = await service.CreateAsync(request);

	Results.Created($"/books/{book.Id}", book);
})
.WithOpenApi();

app.MapPut("/books/{id:guid}", async (Guid id, UpdateBookRequest request, IBookService service) =>
{
	await service.UpdateAsync(id, request);

	return Results.NoContent();
})
.WithOpenApi();

app.MapDelete("/books/{id:guid}", async (Guid id, IBookService service) =>
{
	await service.DeleteAsync(id);

	return Results.NoContent();
})
.WithOpenApi();

app.Run();
