using OnionArchitecture.PizzaStore.Domain.Exceptions;
using System.Text.Json;

namespace PizzaStore.API.Middleware;
internal sealed class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
        var response = new
        {
            error = exception.Message
        };
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
