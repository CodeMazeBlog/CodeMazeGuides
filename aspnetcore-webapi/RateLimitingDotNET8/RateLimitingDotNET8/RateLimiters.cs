using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Primitives;
using System.Threading.RateLimiting;

namespace RateLimitingDotNET8;

public static class RateLimiters
{
    public static void FixedRateLimiter(WebApplicationBuilder builder)
    {
        var fixedOptions = builder.Configuration.GetSection(FixedOptions.Fixed).Get<FixedOptions>();

        builder.Services.AddRateLimiter(options => options
            .AddFixedWindowLimiter(policyName: Policies.Fixed, options =>
            {
                options.PermitLimit = fixedOptions!.PermitLimit;
                options.Window = TimeSpan.FromMinutes(fixedOptions.Window);
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = fixedOptions.QueueLimit;
            }));
    }

    public static void SlidingRateLimiter(WebApplicationBuilder builder)
    {
        var slidingOptions = builder.Configuration.GetSection(SlidingWindowOptions.Sliding).Get<SlidingWindowOptions>();

        builder.Services.AddRateLimiter(options => options
            .AddSlidingWindowLimiter(policyName: Policies.Sliding, options =>
            {
                options.PermitLimit = slidingOptions!.PermitLimit;
                options.Window = TimeSpan.FromMinutes(slidingOptions.Window);
                options.SegmentsPerWindow = slidingOptions.SegmentsPerWindow;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = slidingOptions.QueueLimit;
            }));
    }

    public static void TokenBucketRateLimiter(WebApplicationBuilder builder)
    {
        var bucketOptions = builder.Configuration.GetSection(TokenBucketOptions.Token).Get<TokenBucketOptions>();

        builder.Services.AddRateLimiter(options => options
            .AddTokenBucketLimiter(policyName: Policies.Token, options =>
            {
                options.TokenLimit = bucketOptions!.TokenLimit;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = bucketOptions.QueueLimit;
                options.ReplenishmentPeriod = TimeSpan.FromMinutes(bucketOptions.ReplenishmentPeriod);
                options.TokensPerPeriod = bucketOptions.TokensPerPeriod;
                options.AutoReplenishment = bucketOptions.AutoReplenishment;
            }));
    }

    public static void ConcurrencyRateLimiter(WebApplicationBuilder builder)
    {
        var concurrentOptions = builder.Configuration.GetSection(ConcurrencyOptions.Concurrency).Get<ConcurrencyOptions>();

        builder.Services.AddRateLimiter(_ => _
            .AddConcurrencyLimiter(policyName: Policies.Concurrency, options =>
            {
                options.PermitLimit = concurrentOptions!.PermitLimit;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = concurrentOptions.QueueLimit;
            }));
    }

    public static void AuthorizationRateLimiter(WebApplicationBuilder builder)
    {
        var authorizedLimiterOptions = builder.Configuration.GetSection(AuthorizedOptions.Authorized).Get<AuthorizedOptions>();

        var unauthorizedLimiterOptions = builder.Configuration.GetSection(UnauthorizedOptions.Unauthorized).Get<UnauthorizedOptions>();

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication("Bearer");

        builder.Services.AddRateLimiter(limiterOptions =>
        {
            limiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            limiterOptions.AddPolicy(policyName: Policies.Authorization, partitioner: httpContext =>
            {
                var accessToken = httpContext.GetTokenAsync("access_token").Result
                                  ?? string.Empty;

                if (!StringValues.IsNullOrEmpty(accessToken))
                {
                    return RateLimitPartition.GetFixedWindowLimiter(accessToken, options =>
                        new FixedWindowRateLimiterOptions
                        {
                            QueueLimit = authorizedLimiterOptions!.QueueLimit,
                            PermitLimit = authorizedLimiterOptions.PermitLimit,
                            Window = TimeSpan.FromMinutes(authorizedLimiterOptions.Window),
                        });
                }

                return RateLimitPartition.GetFixedWindowLimiter("Anon", options =>
                    new FixedWindowRateLimiterOptions
                    {
                        QueueLimit = unauthorizedLimiterOptions!.QueueLimit,
                        PermitLimit = unauthorizedLimiterOptions.PermitLimit,
                        Window = TimeSpan.FromMinutes(unauthorizedLimiterOptions.Window),
                    });
            });
        });
    }

    public static void ChainedRateLimiter(WebApplicationBuilder builder)
    {
        var chainedFirstOptions = builder.Configuration.GetSection(ChainedFirstOptions.ChainedFirst).Get<ChainedFirstOptions>();

        var chainedSecondOptions = builder.Configuration.GetSection(ChainedSecondOptions.ChainedSecond).Get<ChainedSecondOptions>();

        builder.Services.AddRateLimiter(limiterOptions =>
        {
            limiterOptions.GlobalLimiter = PartitionedRateLimiter.CreateChained(
                PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                {
                    var userAgent = httpContext.Request.Headers.UserAgent.ToString();
                    return RateLimitPartition.GetFixedWindowLimiter(
                        userAgent, options => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = chainedFirstOptions!.PermitLimit,
                            Window = TimeSpan.FromSeconds(chainedFirstOptions.Window)
                        });
                }),
                PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                {
                    //  var clientIP = httpContext.Connection.RemoteIpAddress!.ToString();
                    var clientIP = "someIp";
                    return RateLimitPartition.GetFixedWindowLimiter(
                        clientIP, options => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = chainedSecondOptions!.PermitLimit,
                            Window = TimeSpan.FromSeconds(chainedSecondOptions.Window)
                        });
                }));
        });
    }

    public static void MinimalApiRateLimiting(WebApplication app)
    {
        app.MapGet("/myendpoint", () => "This endpoint is Rate Limited.")
            .RequireRateLimiting(Policies.Concurrency);

        app.MapGet("/jwt", () => "This endpoint has Authorization Rate Limiter.")
        .RequireRateLimiting(Policies.Authorization)
        .RequireAuthorization();
    }
}
