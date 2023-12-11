using Microsoft.AspNetCore.Mvc.Filters;

namespace ReadingRequestBody.Utils;

[AttributeUsage(AttributeTargets.Method)]
public class ReadRequestBodyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var requestBody = await context.HttpContext.Request.Body.ReadAsStringAsync();
        context.HttpContext.Request.Headers.Append("ReadRequestBodyAttribute", requestBody);

        await next();
    }
}
