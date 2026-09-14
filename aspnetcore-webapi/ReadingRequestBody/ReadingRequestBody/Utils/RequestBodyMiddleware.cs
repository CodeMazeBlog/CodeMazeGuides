namespace ReadingRequestBody.Utils;

public class RequestBodyMiddleware(RequestDelegate next, ILogger<RequestBodyMiddleware> logger)
{
    private const int MaxContentLength = 1024;

    public async Task Invoke(HttpContext context)
    {
        var requestPath = context.Request.Path.Value ?? string.Empty;

        if (requestPath.Contains("read-from-middleware", StringComparison.OrdinalIgnoreCase))
        {
            if (context.Request.ContentLength > MaxContentLength)
            {
                context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
                await context.Response.WriteAsync("Request Body Too Large");

                return;
            }

            context.Request.EnableBuffering(bufferThreshold: MaxContentLength, bufferLimit: MaxContentLength);
            var requestBody = await context.Request.Body.ReadAsStringAsync(true);

            logger.LogInformation("Request Body:{@requestBody}", requestBody);
            context.Request.Headers.Append("RequestBodyMiddleware", requestBody);
            context.Items.Add("RequestBody", requestBody);
            context.Request.Body.Position = 0;
        }

        await next(context);
    }
}
