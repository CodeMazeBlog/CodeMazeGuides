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

    [Theory]
    [InlineData("/Customer/Get", 4)]
    public async Task WhenConcurrencyRateLimitedEndpoint_ThenCannotHaveMoreThan10ConcurrentRequests(string url, int limit)
    {
        var tasks = new List<Task<HttpResponseMessage>>();

        using var semaphore = new SemaphoreSlim(4, 4);

        for (int i = 0; i < limit; i++)
        {
            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    await semaphore.WaitAsync();

                    return await _client.GetAsync(url);
                }
                finally
                {
                    semaphore.Release();
                }

            }));
        }

        var responses = await Task.WhenAll(tasks);

        // Check if any response returned the HTTP 429 Too Many Requests status.
        bool rateLimitExceeded = responses.Any(response => response.StatusCode == HttpStatusCode.TooManyRequests);

        Assert.True(rateLimitExceeded);
    }
}

