using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace UploadingLargeFiles.Utilities
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ContentTypeValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var contentType = context.HttpContext.Request.ContentType ?? string.Empty;
            if (string.IsNullOrEmpty(context.HttpContext.Request.ContentType)
                || contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) < 0)
            {
                context.Result = new BadRequestObjectResult("The request could not be processed. Please make sure the Content-Type header is set to 'multipart/form-data'.");
            }

            base.OnActionExecuting(context);
        }
    }
}