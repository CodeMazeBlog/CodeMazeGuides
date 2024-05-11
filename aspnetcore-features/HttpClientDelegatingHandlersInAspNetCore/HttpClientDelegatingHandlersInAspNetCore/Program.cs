using HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddTransient<SimpleHandler>()
    .AddTransient<AuthorizationHandler>()
    .AddTransient<MetricsHandler>();

builder.Services
    .AddHttpClient("ExtendedClient", (httpClient) =>
    {
        httpClient.BaseAddress = new Uri("http://localhost:5000");
    })
    .AddHttpMessageHandler<SimpleHandler>();

builder.Services
    .AddHttpClient("ChainedClient", (httpClient) =>
    {
        httpClient.BaseAddress = new Uri("http://localhost:5000");
    })
    .AddHttpMessageHandler<AuthorizationHandler>()
    .AddHttpMessageHandler<MetricsHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/api/external-service", async () =>
{
    var randomMilliseconds = new Random().Next(20, 1000);
    var delayTimeSpan = TimeSpan.FromMilliseconds(randomMilliseconds);

    await Task.Delay(delayTimeSpan);

    return Results.Ok();
});

app.MapGet("/api/simple-handler-demo", async (IHttpClientFactory clientFactory) =>
{
    using var httpClient = clientFactory.CreateClient("ExtendedClient");

    var response = await httpClient.GetAsync("/api/external-service");

    return Results.Ok(response);
});

app.MapGet("/api/chanined-handlers-demo", async (IHttpClientFactory clientFactory) =>
{
    using var httpClient = clientFactory.CreateClient("ChainedClient");

    var response = await httpClient.GetAsync("/api/external-service");

    return Results.Ok(response);
});

app.Run();
