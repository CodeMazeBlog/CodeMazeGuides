using IExceptionHandlerInterface.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IExceptionHandlerInterface.Middleware;

public class BadRequestExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public BadRequestExceptionHandler(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError($"Bad request exception: {exception.Message}");

        if (exception is not BadHttpRequestException badRequestException)
        {
            return false;
        }

        var errorResponse = new ErrorResponse
        {
            StatusCode = (int)HttpStatusCode.BadRequest,
            Title = "Bad Request",
            Message = badRequestException.Message
        };

        httpContext.Response.StatusCode = errorResponse.StatusCode;

        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

        return true;
    }
}
