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
            Console.WriteLine(headerValue);
        }
    }
}
