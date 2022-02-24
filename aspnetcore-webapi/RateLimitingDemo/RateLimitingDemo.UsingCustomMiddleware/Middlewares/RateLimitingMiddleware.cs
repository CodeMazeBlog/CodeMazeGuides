using Microsoft.Extensions.Caching.Distributed;
using RateLimitingDemo.UsingCustomMiddleware.Decorators;
using RateLimitingDemo.UsingCustomMiddleware.Extensions;
using System.Net;

namespace RateLimitingDemo.UsingCustomMiddleware.Middlewares;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDistributedCache _cache;

    public RateLimitingMiddleware(RequestDelegate next, IDistributedCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.GetEndpoint();
        var rateLimitingDecorator = endpoint?.Metadata.GetMetadata<LimitRequests>();

        if (rateLimitingDecorator is null)
        {
            await _next(context);
            return;
        }

        var key = GenerateClientKey(context);
        var clientStatistics = await GetClientStatisticsByKey(key);

        if (clientStatistics != null && DateTime.UtcNow < clientStatistics.LastSuccessfulResponseTime.AddSeconds(rateLimitingDecorator.TimeWindow) && clientStatistics.NumberOfRequestsCompletedSuccessfully == rateLimitingDecorator.MaxRequests)
        {
            context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
            return;
        }

        await UpdateClientStatisticsStorage(key, rateLimitingDecorator.MaxRequests);
        await _next(context);
    }

    private static string GenerateClientKey(HttpContext context) => $"{context.Request.Path}_{context.Connection.RemoteIpAddress}";

    private async Task<ClientStatistics> GetClientStatisticsByKey(string key) => await _cache.GetCacheValueAsync<ClientStatistics>(key);

    private async Task UpdateClientStatisticsStorage(string key, int maxRequests)
    {
        var clientStat = await _cache.GetCacheValueAsync<ClientStatistics>(key);

        if (clientStat != null)
        {
            clientStat.LastSuccessfulResponseTime = DateTime.UtcNow;

            if (clientStat.NumberOfRequestsCompletedSuccessfully == maxRequests)
                clientStat.NumberOfRequestsCompletedSuccessfully = 1;

            else
                clientStat.NumberOfRequestsCompletedSuccessfully++;

            await _cache.SetCahceValueAsync<ClientStatistics>(key, clientStat);
        }
        else
        {
            var clientStatistics = new ClientStatistics
            {
                LastSuccessfulResponseTime = DateTime.UtcNow,
                NumberOfRequestsCompletedSuccessfully = 1
            };

            await _cache.SetCahceValueAsync<ClientStatistics>(key, clientStatistics);
        }

    }
}

public class ClientStatistics
{
    public DateTime LastSuccessfulResponseTime { get; set; }
    public int NumberOfRequestsCompletedSuccessfully { get; set; }
}