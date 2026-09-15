using Contracts;
using Microsoft.AspNetCore.Diagnostics;

namespace AccountOwnerServer.Errors
{
    // Registered once in Program.cs. Returning true is what stops the exception
    // propagating; a handler that returns false falls through to the next one.
    public class GlobalExceptionHandler(ILoggerManager logger) : IExceptionHandler
    {
        private readonly ILoggerManager _logger = logger;

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError($"Something went wrong: {exception.Message}");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(
                new { statusCode = httpContext.Response.StatusCode, message = "Internal Server Error" },
                cancellationToken);

            return true;
        }
    }
}
