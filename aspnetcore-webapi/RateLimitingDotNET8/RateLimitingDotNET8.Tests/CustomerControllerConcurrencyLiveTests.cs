using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Xunit.Abstractions;

namespace RateLimitingDotNET8.Tests;

public class CustomerControllerConcurrencyLiveTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public CustomerControllerConcurrencyLiveTests(ITestOutputHelper output, WebApplicationFactory<Program> factory)
    {
        _output = output;

        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication(defaultScheme: "TestScheme")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                        "TestScheme", options => { });

            });
        })
        .CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false,
        });
    }

    [Theory]
    [InlineData("/Customer/Get")]
    public async Task WhenConcurrencyRateLimitedEndpoint_ThenCannotHaveMoreThan1ConcurrentRequests(string url)
    {
        var tasks = new List<Task<HttpResponseMessage>>();
        var threads = Math.Max(Environment.ProcessorCount, 4);
        _output.WriteLine($"Threads: {threads}");

        using var eventSlim = new ManualResetEventSlim(false);
        for (var i = 0; i < threads; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                eventSlim.Wait(TimeSpan.FromSeconds(1));
                
                return await _client.GetAsync(url);
            }));
        }

        eventSlim.Set();

        var responses = await Task.WhenAll(tasks);

        // Check if any response returned the HTTP 429 Too Many Requests status.
        var rateLimitExceeded = responses.Any(response => response.StatusCode == HttpStatusCode.TooManyRequests);

        Assert.True(rateLimitExceeded);
    }
}

