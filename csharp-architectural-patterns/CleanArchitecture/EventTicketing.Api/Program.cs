using EventTicketing.Api.Endpoints;
using EventTicketing.Application;
using EventTicketing.Infrastructure;
using EventTicketing.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Ticketing")!);

builder.Services.AddProblemDetails();
builder.Services.AddValidation();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    await app.Services.SeedDatabaseAsync();
}

app.MapEventEndpoints();

app.Run();
