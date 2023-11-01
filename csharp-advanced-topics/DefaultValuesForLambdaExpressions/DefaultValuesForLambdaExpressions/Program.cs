using DefaultValuesForLambdaExpressions.Models;
using DefaultValuesForLambdaExpressions.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiDbContext>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/item", async (ApiDbContext db, string title, string description = "Lorem Ipsum") =>
{
    try
    {
        var item = new TodoItem
        {
            Title = title,
            Description = description
        };

        await db.AddAsync(item);
        await db.SaveChangesAsync();

        return Results.Ok(item);
    }
    catch (Exception e)
    {
        return Results.Problem($"Error: {e.Message}");
    }
});

app.MapPut("/updateTags", async (ApiDbContext db, int id, params string[] tags) =>
{
    try
    {
        var item = await db.TodoItems.FindAsync(id);
        if (item is null)
        {
            return Results.NotFound();
        }

        item.Tags = string.Join(";", tags);
        await db.SaveChangesAsync();

        return Results.Ok(item);
    }
    catch (Exception e)
    {
        return Results.Problem($"Error: {e.Message}");
    }
});

app.Run();

public partial class Program { }