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
    public async Task WhenEndpointCalled_ThenEndpointsReturnSuccess(string url)
    {
        var response = await _client.GetAsync(url);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Theory]
    [InlineData("/Customer/Details", 9)]
    [InlineData("/Customer/GetById", 9)]
    [InlineData("/Customer/Get", 9)]
    public async Task WhenRateLimitedEndpointsUnderLimit_ThenReturnsOk(string url, int limit)
    {
        for (int i = 0; i < limit; i++)
        {
            var response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }

    [Theory]
    [InlineData("/Customer/Details", 20)]
    [InlineData("/Customer/GetById", 20)]
    public async Task WhenRateLimitedEndpointsExceedLimit_ThenReturnsTooManyRequests(string url, int limit)
    {
        HttpStatusCode lastStatusCode = HttpStatusCode.OK;

        for (int i = 0; i < limit; i++)
        {
            var response = await _client.GetAsync(url);
            lastStatusCode = response.StatusCode;
            // Break as soon as the rate limit has been reached.
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                break;
            }
        }

        Assert.Equal(HttpStatusCode.TooManyRequests, lastStatusCode);
    }

    [Theory]
    [InlineData("/Customer/SpecialOffer", 100)]
    public async Task WhenRateLimitingNotEnforcedOnSpecialOffer_ThenAlwaysSuccessStatusCode(string url, int limit)
    {
        // Make a high number of requests assuming it exceeds any reasonable limit
        for (int i = 0; i < limit; i++)
        {
            var response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
