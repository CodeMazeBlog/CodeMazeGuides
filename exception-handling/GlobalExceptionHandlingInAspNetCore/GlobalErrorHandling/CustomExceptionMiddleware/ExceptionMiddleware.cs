namespace GlobalErrorHandling.CustomExceptionMiddleware;

public class ExceptionMiddleware(
    RequestDelegate next,
    ILogger<ExceptionMiddleware> logger,
    IProblemDetailsService problemDetailsService)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (AccessViolationException avEx)
        {
            logger.LogError(avEx, "A new violation exception has been thrown");
            await HandleExceptionAsync(httpContext, avEx);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something went wrong");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var message = exception switch
        {
            AccessViolationException => "Access violation error from the custom middleware",
            _ => "Internal Server Error from the custom middleware."
        };

        await problemDetailsService.WriteAsync(new ProblemDetailsContext
        {
            HttpContext = context,
            Exception = exception,
            ProblemDetails = { Detail = message }
        });
    }
}
