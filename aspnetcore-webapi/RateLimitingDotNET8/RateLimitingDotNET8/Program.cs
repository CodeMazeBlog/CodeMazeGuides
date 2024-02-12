using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using RateLimitingDotNET8;
using System.Globalization;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSettings(builder.Configuration);

FixedRateLimiter(builder);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void FixedRateLimiter(WebApplicationBuilder builder)
{
    var myOptions = builder.Configuration.Get<MyRateLimiterOptions>();

builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: Policies.Fixed, options =>
    {
        options.PermitLimit = myOptions!.PermitLimit;
        options.Window = TimeSpan.FromSeconds(myOptions.Window);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = myOptions.QueueLimit;
    }));
}

static void SlidingRateLimiter(WebApplicationBuilder builder)
{
    var slidingOptions = builder.Configuration.Get<SlidingOptions>();

builder.Services.AddRateLimiter(_ => _
    .AddSlidingWindowLimiter(policyName: Policies.Sliding, options =>
    {
        options.PermitLimit = slidingOptions!.PermitLimit;
        options.Window = TimeSpan.FromSeconds(slidingOptions.Window);
        options.SegmentsPerWindow = slidingOptions.SegmentsPerWindow;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = slidingOptions.QueueLimit;
    }));
}

static void TokenBucketRateLimiter(WebApplicationBuilder builder)
{
    var myOptions = builder.Configuration.Get<TokenBucketOptions>();

builder.Services.AddRateLimiter(options => options
    .AddTokenBucketLimiter(policyName: Policies.Token, options =>
    {
        options.TokenLimit = myOptions!.TokenLimit;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = myOptions.QueueLimit;
        options.ReplenishmentPeriod = TimeSpan.FromSeconds(myOptions.ReplenishmentPeriod);
        options.TokensPerPeriod = myOptions.TokensPerPeriod;
        options.AutoReplenishment = myOptions.AutoReplenishment;
    }));
}

static void ConcurrencyRateLimiter(WebApplicationBuilder builder)
{
    var myOptions = builder.Configuration.Get<MyRateLimiterOptions>();

builder.Services.AddRateLimiter(_ => _
    .AddConcurrencyLimiter(policyName: Policies.Concurrency, options =>
    {
        options.PermitLimit = myOptions!.PermitLimit;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = myOptions.QueueLimit;
    }));
}

static void AuthorizationRateLimiter(WebApplicationBuilder builder)
{
    var authorizedLimiterOptions = builder.Configuration.Get<MyRateLimiterOptions>();

    var unauthorizedLimiterOptions = builder.Configuration.Get<MyRateLimiterOptions>();

    builder.Services.AddRateLimiter(limiterOptions =>
    {
        limiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        limiterOptions.AddPolicy(policyName: "jwt", partitioner: httpContext =>
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
    
            return RateLimitPartition.GetFixedWindowLimiter("Anon", _ =>
                new FixedWindowRateLimiterOptions
                {
                    QueueLimit = unauthorizedLimiterOptions!.QueueLimit,
                    PermitLimit = unauthorizedLimiterOptions.PermitLimit,
                    Window = TimeSpan.FromMinutes(unauthorizedLimiterOptions.Window),
                });
        });
    });
}

static void ChainedRateLimiter(WebApplicationBuilder builder)
{
    builder.Services.AddRateLimiter(limiterOptions =>
    {
        limiterOptions.GlobalLimiter = PartitionedRateLimiter.CreateChained(
            PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                var userAgent = httpContext.Request.Headers.UserAgent.ToString();
                return RateLimitPartition.GetFixedWindowLimiter(
                    userAgent, _ => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 4,
                        Window = TimeSpan.FromSeconds(2)
                    });
            }),
            PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            {
                var clientIP = httpContext.Connection.RemoteIpAddress!.ToString();
                return RateLimitPartition.GetFixedWindowLimiter(
                    clientIP, _ => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 20,
                        Window = TimeSpan.FromSeconds(30)
                    });
            }));
    });
}

