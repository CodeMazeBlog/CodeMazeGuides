using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DependencyInjectionLifetimeScopes
{
public class MyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;                    
    public readonly IMySingletonService _mySingletonService;

    public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger,                         
        IMySingletonService mySingletonService)
    {
        _logger = logger;            
        _mySingletonService = mySingletonService;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,
        IMyScopedService myScopedService, IMyTransientService myTransientService)
    {
        _logger.LogInformation("Transient: " + myTransientService.InstanceId);
        _logger.LogInformation("Scoped: " + myScopedService.InstanceId);
        _logger.LogInformation("Singleton: " + _mySingletonService.InstanceId);

        await _next(context);
    }
}

public static class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware>();
    }
}
}
