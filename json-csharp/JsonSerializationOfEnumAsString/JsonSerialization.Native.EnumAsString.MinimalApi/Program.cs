using JsonSerialization.EnumAsString.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.MapGet("/poster", () => Canvas.Poster);
app.MapGet("/schedule", () => new { Description = "Exhibition", Day = DayOfWeek.Monday });

app.Run();