var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();

// WebApplicationFactory<Program> in the test project needs Program to be a nameable,
// accessible type. Top-level statements generate an internal one, so we declare it here.
public partial class Program;