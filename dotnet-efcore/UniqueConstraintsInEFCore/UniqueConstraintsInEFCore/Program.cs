using Microsoft.EntityFrameworkCore;
using UniqueConstraintsInEFCore.Data;
using UniqueConstraintsInEFCore.Data.Models;
using UniqueConstraintsInEFCore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddHostedService<InitializationService>();

builder.Services.AddDbContext<SolarSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SolarSystemDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/planets", async (Planet planet, SolarSystemDbContext context) =>
{
    try
    {
        context.Planets.Add(planet);
        await context.SaveChangesAsync();

        return Results.Created($"/planets/{planet.Id}", planet);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest();
    }
})
.WithName("AddPlanet");

app.Run();

public partial class Program { }
