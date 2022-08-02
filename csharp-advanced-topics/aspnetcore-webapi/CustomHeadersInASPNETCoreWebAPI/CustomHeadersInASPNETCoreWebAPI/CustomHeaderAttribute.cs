using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomHeadersInASPNETCoreWebAPI
{
    public class CustomHeaderAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("x-my-custom-header", "attribute response");
            base.OnResultExecuting(context);
        }
    }
}
