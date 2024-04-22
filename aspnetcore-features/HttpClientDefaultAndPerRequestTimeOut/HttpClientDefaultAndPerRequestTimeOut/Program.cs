using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("TestClient", (sp, httpClient) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var timeoutSeconds = configuration.GetValue<int>("TestClient:TimeOutSeconds");

    httpClient.BaseAddress = new Uri("http://localhost:5000");
    httpClient.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/api/delay-4-seconds", async (CancellationToken cancellationToken) => await Task.Delay(TimeSpan.FromSeconds(4), cancellationToken));

app.MapGet("/api/test-global-timeout", async (IHttpClientFactory httpClientFactory) =>
{
    var httpClient = httpClientFactory.CreateClient("TestClient");

    try
    {
        var response = await httpClient.GetAsync("/api/delay-4-seconds");

        return Results.Ok();
    }
    catch (TaskCanceledException)
    {
        return Results.Text("TaskCanceledException: HttpClient global timeout passed");
    }
});


app.MapGet("/api/test-per-request-timeout", async (IHttpClientFactory httpClientFactory, CancellationToken cancellationToken) =>
{
    var httpClient = httpClientFactory.CreateClient("TestClient");

    try
    {
        var response = await httpClient.GetAsync($"/api/delay-4-seconds", cancellationToken);

        return Results.Ok();
    }
    catch (TaskCanceledException)
    {
        return Results.Text("TaskCanceledException: User request cancelled");
    }
});

app.MapGet("/api/test-combined-timeout", async (IHttpClientFactory httpClientFactory, CancellationToken cancellationToken) =>
{
    var httpClient = httpClientFactory.CreateClient("TestClient");
    using var endpointSpecificToken = new CancellationTokenSource(TimeSpan.FromSeconds(2));
    using var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, endpointSpecificToken.Token);

    try
    {
        var response = await httpClient.GetAsync("/api/delay-4-seconds", tokenSource.Token);

        return Results.Ok();
    }
    catch (TaskCanceledException)
    {
        return endpointSpecificToken.IsCancellationRequested
            ? Results.Text("TaskCanceledException: Specific token canceled")
            : Results.Text("TaskCanceledException: HttpClient global timeout passed");
    }
});

app.Run();
