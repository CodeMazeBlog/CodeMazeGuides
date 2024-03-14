using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace RateLimitingDotNET8.Tests;

public class CustomerControllerTestsConcurrency : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CustomerControllerTestsConcurrency(WebApplicationFactory<Program> factory)
    {
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

    [Fact]
    public async Task WhenConcurrencyRateLimitedEndpoint_ThenCannotHaveMoreThan10ConcurrentRequests()
    {
        var tasks = new List<Task<HttpResponseMessage>>();

        for (int i = 0; i < 12; i++)
        {
            tasks.Add(_client.GetAsync("/Customer/Get"));
        }

        var responses = await Task.WhenAll(tasks);

        // Check if any response returned the HTTP 429 Too Many Requests status.
        bool rateLimitExceeded = responses.Any(response => response.StatusCode == HttpStatusCode.TooManyRequests);

        Assert.True(rateLimitExceeded);
    }
}

