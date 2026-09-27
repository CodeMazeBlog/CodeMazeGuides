using Microsoft.AspNetCore.Diagnostics;

namespace GlobalErrorHandling.ExceptionHandlers;

public class AccessViolationExceptionHandler(
    IProblemDetailsService problemDetailsService,
    ILogger<AccessViolationExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not AccessViolationException)
            return false;

        logger.LogError(exception, "A new violation exception has been thrown");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = { Detail = "Access violation error from the exception handler" }
        });
    }
}
