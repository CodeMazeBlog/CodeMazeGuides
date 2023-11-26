namespace ReadingRequestBody.Utils;

public class RequestBodyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    private readonly int MaxContentLength = 1024;

    public RequestBodyMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestPath = context.Request.Path.Value;

        if (requestPath.IndexOf("read-from-middleware") > -1)
        {
            context.Request.EnableBuffering();
            var requestBody = await context.Request.Body.ReadAsStringAsync(true);

            if (requestBody.Length > MaxContentLength)
            {
                context.Response.StatusCode = 413;
                await context.Response.WriteAsync("Request Body Too Large");
                return;
            }

            _logger.LogInformation("Request Body:{@requestBody}", requestBody);
            context.Request.Headers.Append("RequestBodyMiddleware", requestBody);
            context.Items.Add("RequestBody", requestBody);
            context.Request.Body.Position = 0;
        }

        await _next(context);
    }
}