using Microsoft.AspNetCore.Mvc.Filters;

namespace ReadingRequestBody.Utils;

public class ReadRequestBodyActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var requestPath = context.HttpContext.Request.Path.Value;
        if (requestPath.IndexOf("read-from-action-filter") > -1)
        {
            using StreamReader reader = new(context.HttpContext.Request.Body);
            string requestBody = reader.ReadToEnd();
            context.HttpContext.Request.Headers.Add("ReadRequestBodyActionFilter", requestBody);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Executed after the action method
    }
}
