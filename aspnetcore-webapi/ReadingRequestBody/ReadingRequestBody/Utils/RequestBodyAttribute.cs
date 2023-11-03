using Microsoft.AspNetCore.Mvc.Filters;

namespace ReadingRequestBody.Utils;

[AttributeUsage(AttributeTargets.Method)]
public class ReadRequestBodyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        using (StreamReader reader = new(context.HttpContext.Request.Body))
        {
            string requestBody = await reader.ReadToEndAsync();
            context.HttpContext.Request.Headers.Add("ReadRequestBodyAttribute", requestBody);
        }

        await next();
    }
}
