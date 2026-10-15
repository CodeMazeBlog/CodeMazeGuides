using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

const string policyName = "CorsPolicy";
const string anotherPolicyName = "AnotherCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
    {
        builder.WithOrigins("https://localhost:5011")
            .AllowAnyHeader()
            .WithMethods("GET");
    });
    options.AddPolicy(name: anotherPolicyName, builder =>
    {
        builder.WithOrigins("https://localhost:5021")
            .WithHeaders(HeaderNames.ContentType, HeaderNames.Accept)
            .WithMethods("GET")
            .WithExposedHeaders("X-Pagination");
    });
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
    app.UseHsts();
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/minimal/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .RequireCors(policyName);

app.Run();

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
