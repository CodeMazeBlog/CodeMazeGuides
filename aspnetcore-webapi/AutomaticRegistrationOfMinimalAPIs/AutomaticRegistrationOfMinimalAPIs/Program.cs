using AutomaticRegistrationOfMinimalAPIs.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseInMemoryDatabase("School"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/something", () =>
{
    return Results.Ok("anything");
})
.WithOpenApi();

app.Run();

public partial class Program { }
