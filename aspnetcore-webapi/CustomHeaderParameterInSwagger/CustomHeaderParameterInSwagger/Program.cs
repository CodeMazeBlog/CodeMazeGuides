using GlobalHeaderParameterInSwagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Global Header Example", Version = "v1" });
    c.OperationFilter<CustomHeaderParameter>();
});

var app = builder.Build();

app.MapGet("/api/sample", (HttpContext httpContext) =>
{
    if (!httpContext.Request.Headers.TryGetValue("X-Custom-Header", out var headerValue) || headerValue != "secret-key")
    {
        return Results.Unauthorized();
    }

    return Results.Ok("Successfully authenticated with custom header!");
});

app.MapPost("/api/sample", (HttpContext httpContext) =>
{
    if (!httpContext.Request.Headers.TryGetValue("X-Custom-Header", out var headerValue) || headerValue != "secret-key")
    {
        return Results.Unauthorized();
    }

    return Results.Ok("Successfully authenticated with custom header!");
});


app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Global Header Example v1");
    c.DefaultModelsExpandDepth(-1);
    c.DocExpansion(DocExpansion.List);
});

app.UseRouting();

app.Run();

public partial class Program { }