using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace ExtractCustomHeader
{
    public class ExtractCustomHeaderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            const string HEADER_KEY_NAME = "FilterHeaderKey";
            context.HttpContext.Request.Headers.TryGetValue(HEADER_KEY_NAME, out StringValues headerValue);

            if (context.HttpContext.Items.ContainsKey(HEADER_KEY_NAME))
            {
                context.HttpContext.Items[HEADER_KEY_NAME] = headerValue;
            }
            else
            {
                context.HttpContext.Items.Add(HEADER_KEY_NAME, $"{headerValue}-received");
            }
        }
    }
}
