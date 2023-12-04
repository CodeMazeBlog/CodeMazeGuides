using Microsoft.AspNetCore.Mvc.Filters;

namespace ReadingRequestBody.Utils;

public class ReadRequestBodyActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var requestPath = context.HttpContext.Request.Path.Value;

        if (requestPath.IndexOf("read-from-action-filter") > -1)
        {
            var requestBody = await context.HttpContext.Request.Body.ReadAsStringAsync();
            context.HttpContext.Request.Headers.Append("ReadRequestBodyActionFilter", requestBody);
        }

        await next();
    }
}
