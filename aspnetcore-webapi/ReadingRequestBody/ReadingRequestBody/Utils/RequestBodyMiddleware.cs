namespace ReadingRequestBody.Utils;

public class RequestBodyMiddleware
{
    private readonly RequestDelegate _next;
    public RequestBodyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var requestPath = context.Request.Path.Value;
        if (requestPath.IndexOf("read-from-middleware") > -1)
        {
            context.Request.EnableBuffering();

            using StreamReader reader = new(context.Request.Body);
            string requestBody = await reader.ReadToEndAsync();
            context.Request.Headers.Add("RequestBodyMiddleware", requestBody);

            context.Request.Body.Position = 0;
        }

        await _next(context);
    }
}