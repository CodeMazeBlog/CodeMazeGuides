using HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddTransient<SimpleHandler>()
    .AddTransient<AuthorizationHandler>()
    .AddTransient<MetricsHandler>()
    .AddTransient<TransientIdentifiableHandler>();

builder.Services.AddHttpClient("ExtendedClient", (httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7133");
})
.AddHttpMessageHandler<SimpleHandler>();

builder.Services.AddHttpClient("ChainedClient", (httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7133");
})
.AddHttpMessageHandler<AuthorizationHandler>()
.AddHttpMessageHandler<MetricsHandler>();

builder.Services.AddHttpClient("HandlerLifeTimeDemoClient", (httpClient) =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7133");
})
.AddHttpMessageHandler<TransientIdentifiableHandler>()
.SetHandlerLifetime(TimeSpan.FromSeconds(1));

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

app.MapGet("/api/chained-handlers-demo", async (IHttpClientFactory clientFactory) =>
{
    using var httpClient = clientFactory.CreateClient("ChainedClient");

    var response = await httpClient.GetAsync("/api/external-service");

    return Results.Ok(response);
});

app.MapGet("/api/handler-lifetime-demo", async (IHttpClientFactory clientFactory) =>
{
    using var httpClient1 = clientFactory.CreateClient("HandlerLifeTimeDemoClient");
    var response1 = await httpClient1.GetAsync("/api/external-service");

    await Task.Delay(TimeSpan.FromSeconds(2));

    using var httpClient2 = clientFactory.CreateClient("HandlerLifeTimeDemoClient");
    var response2 = await httpClient2.GetAsync("/api/external-service");

    return Results.Ok(new[] { response1, response2 });
});

app.Run();