namespace ConditionalMiddleware;
public class DevelopmentLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<DevelopmentLoggingMiddleware> _logger;

    public DevelopmentLoggingMiddleware(RequestDelegate next, ILogger<DevelopmentLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("Handling request: {RequestPath}", context.Request.Path);
        await _next(context);
        _logger.LogInformation("Finished handling request.");
    }
}