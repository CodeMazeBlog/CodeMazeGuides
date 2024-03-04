using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace RateLimitingDotNET8.Tests;
public class CustomerControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CustomerControllerTests(WebApplicationFactory<Program> factory)
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

        _client.DefaultRequestHeaders.UserAgent.ParseAdd("fakeUserAgent");
        _client.DefaultRequestHeaders.Add("X-Test-RemoteIP", "127.0.0.1");
    }

    [Theory]
    [InlineData("/Customer/Index")]
    [InlineData("/Customer/Details")]
    [InlineData("/Customer/GetById")]
    [InlineData("/Customer/Get")]
    [InlineData("/Customer/SpecialOffer")]
    [InlineData("/myendpoint")]
    [InlineData("/jwt")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        var response = await _client.GetAsync(url);

        response.EnsureSuccessStatusCode();
    }

    [Theory]
    [InlineData("/Customer/Details", 9)]
    [InlineData("/Customer/GetById", 9)]
    [InlineData("/Customer/Get", 9)]
    public async Task RateLimitedEndpoints_ReturnsOk_UnderLimit(string url, int limit)
    {
        for (int i = 0; i < limit; i++)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }

    [Theory]
    [InlineData("/Customer/Details", 20)]
    [InlineData("/Customer/GetById", 20)]
    public async Task RateLimitedEndpointss_ExceedingLimit_ReturnsTooManyRequests(string url, int limit)
    {
        HttpStatusCode lastStatusCode = HttpStatusCode.OK;

        for (int i = 0; i < limit; i++)
        {
            var response = _client.GetAsync(url).Result;
            lastStatusCode = response.StatusCode;
            // Break as soon as the rate limit has been reached.
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                break;
            }
        }

        Assert.Equal(HttpStatusCode.TooManyRequests, lastStatusCode);
    }

    [Fact]
    public async Task RateLimiting_NotEnforcedOnSpecialOffer()
    {
        string url = "/Customer/SpecialOffer";

        // Make a high number of requests assuming it exceeds any reasonable limit
        for (int i = 0; i < 100; i++)
        {
            var response = await _client.GetAsync(url);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

public class CustomerControllerTests2 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CustomerControllerTests2(WebApplicationFactory<Program> factory)
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
    public async Task RateLimitedEndpoint_CannotHaveMoreThan10ConcurrentRequests()
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

