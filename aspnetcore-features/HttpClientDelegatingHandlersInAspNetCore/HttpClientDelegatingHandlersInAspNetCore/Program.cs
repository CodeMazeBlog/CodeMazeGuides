using HttpClientDelegatingHandlersInAspNetCore.DelegatingHandlers;
using HttpClientDelegatingHandlersInAspNetCore.Services.Abstract;
using HttpClientDelegatingHandlersInAspNetCore.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddTransient<IMetricsProvider, MetricsProvider>()
    .AddTransient<ITokenGenerator, TokenGenerator>()
    .AddTransient<SimpleHandler>()
    .AddTransient<AuthorizationHandler>()
    .AddTransient<MetricsHandler>();

builder.Services
    .AddHttpClient("ExtendedClient", (sp, httpClient) =>
    {
        httpClient.BaseAddress = new Uri("http://localhost:5000");
    })
    .AddHttpMessageHandler<SimpleHandler>();

builder.Services
    .AddHttpClient("ChainedClient", (sp, httpClient) =>
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
});

app.MapGet("/api/simple-handler-demo", async (IHttpClientFactory clientFactory) =>
{
    var httpClient = clientFactory.CreateClient("ExtendedClient");

    var response = await httpClient.GetAsync("/api/external-service");
});

app.MapGet("/api/chanined-handlers-demo", async (IHttpClientFactory clientFactory) =>
{
    var httpClient = clientFactory.CreateClient("ChainedClient");

    var response = await httpClient.GetAsync("/api/external-service");
});

app.Run();