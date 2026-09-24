var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("TestClient", (sp, httpClient) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var timeoutSeconds = configuration.GetValue<int>("TestClient:TimeOutSeconds");

    httpClient.BaseAddress = new Uri("http://localhost:5000");
    httpClient.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
});

builder.Services.AddHttpClient("ResilientClient", httpClient =>
{
    httpClient.BaseAddress = new Uri("http://localhost:5000");
})
.AddStandardResilienceHandler(options =>
{
    options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(2);
    options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(8);
});

var app = builder.Build();

app.MapGet("/api/delay-4-seconds", async (CancellationToken cancellationToken) => await Task.Delay(TimeSpan.FromSeconds(4), cancellationToken));

app.MapGet("/api/test-global-timeout", async (IHttpClientFactory httpClientFactory) =>
{
    var httpClient = httpClientFactory.CreateClient("TestClient");

    try
    {
        using var response = await httpClient.GetAsync("/api/delay-4-seconds");

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
        using var response = await httpClient.GetAsync($"/api/delay-4-seconds", cancellationToken);

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
        using var response = await httpClient.GetAsync("/api/delay-4-seconds", tokenSource.Token);

        return Results.Ok();
    }
    catch (TaskCanceledException)
    {
        return endpointSpecificToken.IsCancellationRequested
            ? Results.Text("TaskCanceledException: Specific token canceled")
            : Results.Text("TaskCanceledException: HttpClient global timeout passed");
    }
});

app.MapGet("/api/test-timeout-vs-cancellation", async (IHttpClientFactory httpClientFactory, CancellationToken cancellationToken) =>
{
    var httpClient = httpClientFactory.CreateClient("TestClient");

    try
    {
        using var response = await httpClient.GetAsync("/api/delay-4-seconds", cancellationToken);

        return Results.Ok();
    }
    catch (OperationCanceledException ex) when (ex.InnerException is TimeoutException)
    {
        return Results.Text("The request timed out");
    }
    catch (OperationCanceledException)
    {
        return Results.Text("The caller canceled the request");
    }
});

app.MapGet("/api/test-resilience-timeout", async (IHttpClientFactory httpClientFactory) =>
{
    var httpClient = httpClientFactory.CreateClient("ResilientClient");

    try
    {
        using var response = await httpClient.GetAsync("/api/delay-4-seconds");

        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.Text($"{ex.GetType().Name} after {httpClient.Timeout}");
    }
});

app.Run();
