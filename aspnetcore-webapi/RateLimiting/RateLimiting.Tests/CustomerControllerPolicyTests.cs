using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace RateLimiting.Tests;

public class CustomerControllerPolicyTests : IClassFixture<WebApplicationFactory<Program>>
{
    private const int FixedPermitLimit = 20;
    private const int SlidingPermitLimit = 10;
    private const int TokenLimit = 10;

    private readonly HttpClient _client;

    public CustomerControllerPolicyTests(WebApplicationFactory<Program> factory)
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
    public async Task WhenActionHasNoAttribute_ThenTheControllerPolicyLimitsIt()
    {
        for (var i = 0; i < FixedPermitLimit; i++)
        {
            var allowed = await _client.GetAsync("/Customer/Index");
            Assert.Equal(HttpStatusCode.OK, allowed.StatusCode);
        }

        var rejected = await _client.GetAsync("/Customer/Index");

        Assert.Equal(HttpStatusCode.TooManyRequests, rejected.StatusCode);
    }

    [Fact]
    public async Task WhenActionHasItsOwnAttribute_ThenItOverridesTheControllerPolicy()
    {
        // The controller carries [EnableRateLimiting(Policies.Fixed)] at 20 permits,
        // the action carries [EnableRateLimiting(Policies.Sliding)] at 10. If the
        // controller's policy were the one in force, request 11 would still be allowed.
        for (var i = 0; i < SlidingPermitLimit; i++)
        {
            var allowed = await _client.GetAsync("/Customer/Details");
            Assert.Equal(HttpStatusCode.OK, allowed.StatusCode);
        }

        var rejected = await _client.GetAsync("/Customer/Details");

        Assert.Equal(HttpStatusCode.TooManyRequests, rejected.StatusCode);
    }

    [Fact]
    public async Task WhenATokenBucketRequestIsRejected_ThenOnRejectedWritesRetryAfter()
    {
        HttpResponseMessage? rejected = null;

        for (var i = 0; i <= TokenLimit && rejected is null; i++)
        {
            var response = await _client.GetAsync("/Customer/GetById");
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                rejected = response;
            }
        }

        Assert.NotNull(rejected);
        Assert.True(rejected!.Headers.TryGetValues("Retry-After", out var values));
        Assert.True(int.Parse(values!.Single()) > 0);
    }
}
