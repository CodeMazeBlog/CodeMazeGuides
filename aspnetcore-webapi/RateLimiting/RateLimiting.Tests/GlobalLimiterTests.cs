using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.RateLimiting;

namespace RateLimiting.Tests;

public class GlobalLimiterTests : IClassFixture<WebApplicationFactory<Program>>
{
    private const int GlobalPermitLimit = 5;

    private readonly HttpClient _client;

    public GlobalLimiterTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication(defaultScheme: "TestScheme")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                        "TestScheme", options => { });

                // Repeated AddRateLimiter calls configure the same RateLimiterOptions
                // instance, so this global limiter is added to the ones Program.cs registers.
                services.AddRateLimiter(limiterOptions =>
                {
                    limiterOptions.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(
                        _ => RateLimitPartition.GetFixedWindowLimiter("global", _ =>
                            new FixedWindowRateLimiterOptions
                            {
                                PermitLimit = GlobalPermitLimit,
                                Window = TimeSpan.FromMinutes(1)
                            }));
                });
            });
        })
        .CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false,
        });
    }

    [Fact]
    public async Task WhenTheGlobalLimitIsSpent_ThenAnEndpointInsideItsOwnLimitIsStillRejected()
    {
        // /Customer/Index is under the controller's fixed policy at 20 permits, so
        // anything rejected inside the first six requests came from the global limiter.
        for (var i = 0; i < GlobalPermitLimit; i++)
        {
            var allowed = await _client.GetAsync("/Customer/Index");
            Assert.Equal(HttpStatusCode.OK, allowed.StatusCode);
        }

        var rejected = await _client.GetAsync("/Customer/Index");

        Assert.Equal(HttpStatusCode.TooManyRequests, rejected.StatusCode);
    }

    [Fact]
    public async Task WhenAnActionDisablesRateLimiting_ThenTheGlobalLimiterDoesNotApply()
    {
        for (var i = 0; i < GlobalPermitLimit * 2; i++)
        {
            var response = await _client.GetAsync("/Customer/SpecialOffer");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
