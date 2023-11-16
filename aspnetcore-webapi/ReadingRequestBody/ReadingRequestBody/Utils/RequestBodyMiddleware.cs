using Newtonsoft.Json;
using ReadingRequestBody.Models;

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

        if (requestPath.IndexOf("read-from-middleware") > -1
            || requestPath.IndexOf("read-from-body") > -1)
        {
            context.Request.EnableBuffering();

            string requestBody = await context.Request.Body.ReadAsStringAsync(true);

            //log request body
            _logger.LogInformation("Request Body:{@requestBody}", requestBody);

            //set request body to request header
            context.Request.Headers.Add("RequestBodyMiddleware", requestBody);

            //set request body to context items
            context.Items.Add("RequestBody", requestBody);

            //check content length
            if (requestBody.Length > MaxContentLength)
            {
                context.Response.StatusCode = 413;
                await context.Response.WriteAsync("Request Body Too Large");
                return;
            }

            //Deserialize request body into a model object
            try
            {
                if (requestPath.IndexOf("read-from-body") > -1)
                {
                    var personData = JsonConvert.DeserializeObject<PersonItemDto>(requestBody);
                    context.Items.Add("PersonData", requestBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Deserialize Error");
            }

            context.Request.Body.Position = 0;
        }

        await _next(context);
    }
}