using Microsoft.AspNetCore.Http;
using Serilog;
using TaskManagementSystem.Exceptions.Exceptions.BaseExceprions;
using TaskManagementSystem.Exceptions.Models;

namespace TaskManagementSystem.Exceptions.Middlewares
{
    internal class ExceptionMiddleware
    {
        private static readonly ILogger Logger = Log.ForContext(typeof(ExceptionMiddleware));

        private readonly RequestDelegate _next;

        /// <summary>
        /// Gets HTTP status code response and message to be returned to the caller.
        /// Use the ".Data" property to set the key of the messages if it's localized.
        /// </summary>
        /// <param name="exception">The actual exception</param>
        /// <returns>Tuple of HTTP status code and a message</returns>

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ExtendedCustomException exception)
            {
                Logger.Warning(nameof(ExtendedCustomException));
                Logger.Warning($"Message: {exception.Message}");
                Logger.Information($"Status Code: {exception.StatusCode}");
                Logger.Information($"Error Code: {exception.ErrorCode}");

                var response = new ExtendedErrorResponse(exception);
                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
            catch(CustomException exception)
            {
                Logger.Warning(nameof(CustomException));
                Logger.Warning($"Message: {exception.Message}");
                Logger.Information($"Status Code: {exception.StatusCode}");
                Logger.Information($"Error Code: {exception.ErrorCode}");

                var response = new ErrorResponse(exception);
                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
            catch (Exception exception)
            {
                Logger.Error(exception.GetType().Name);
                Logger.Error(exception.Message);
                if (exception.StackTrace is not null)
                    Logger.Error(exception.StackTrace);

                var response = new ErrorResponse();
                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
