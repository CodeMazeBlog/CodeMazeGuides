using Carter;
using IntroductionToCarter.Data;
using IntroductionToCarter.Services;
using IntroductionToCarter.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarter();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseInMemoryDatabase("Books"));

var app = builder.Build();

app.MapCarter();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

public partial class Program { }
