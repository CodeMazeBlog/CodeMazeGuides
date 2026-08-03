using ConditionalMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<DevelopmentLoggingMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapWhen(context => context.Request.Path.ToString() == "/api/WeatherForecast/update-weather", appBuilder =>
{
    appBuilder.UseMiddleware<DevelopmentLoggingMiddleware>();
    appBuilder.UseRouting();
    appBuilder.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});

app.UseWhen(context => context.Request.Headers.ContainsKey("X-Custom-Header") &&
context.Request.Method == "POST" && context.Request.Query.ContainsKey("active"), appBuilder =>
{
    appBuilder.UseMiddleware<DevelopmentLoggingMiddleware>();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
