using Microsoft.EntityFrameworkCore;
using UniqueConstraintsInEFCore.Data;
using UniqueConstraintsInEFCore.Data.Models;
using UniqueConstraintsInEFCore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<InitializationService>();

builder.Services.AddDbContext<SolarSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SolarSystemDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/planets", async (Planet planet, SolarSystemDbContext context) =>
{
    try
    {
        await context.Planets.AddAsync(planet);
        await context.SaveChangesAsync();

        return Results.Created($"/planets/{planet.Id}", planet);
    }
    catch
    {
        return Results.BadRequest();
    }
})
.WithName("AddPlanet")
.WithOpenApi();

app.Run();

public partial class Program { }
