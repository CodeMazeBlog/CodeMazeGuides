namespace MediatrExceptionHandler
{
    using System.Diagnostics;
    using System.Net;
    using System.Text.Json;

    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var exception = ex.Demystify();

                _logger.LogError(exception, "An error ocurred: {Message}", exception.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(new { error = "A server error ocurred" });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
