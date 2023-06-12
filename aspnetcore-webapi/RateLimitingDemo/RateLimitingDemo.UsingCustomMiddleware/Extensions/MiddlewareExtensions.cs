using RateLimitingDemo.UsingCustomMiddleware.Middlewares;

namespace RateLimitingDemo.UsingCustomMiddleware.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRateLimiting(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RateLimitingMiddleware>();
    }
}

