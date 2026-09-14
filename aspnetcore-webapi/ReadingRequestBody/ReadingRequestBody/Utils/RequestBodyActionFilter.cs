using Microsoft.AspNetCore.Mvc.Filters;

namespace ReadingRequestBody.Utils;

public class ReadRequestBodyActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var requestPath = context.HttpContext.Request.Path.Value ?? string.Empty;

        if (requestPath.Contains("read-from-action-filter", StringComparison.OrdinalIgnoreCase))
        {
            var requestBody = await context.HttpContext.Request.Body.ReadAsStringAsync();
            context.HttpContext.Request.Headers.Append("ReadRequestBodyActionFilter", requestBody);
        }

        await next();
    }
}
