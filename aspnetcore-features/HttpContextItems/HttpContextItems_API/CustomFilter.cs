using Microsoft.AspNetCore.Mvc.Filters;

namespace HttpContextItems_API
{
    public class CustomFilter : IActionFilter
    {
        private readonly ILogger<CustomFilter> _logger;
        public static readonly object FilterObjectKey = new();

        public CustomFilter(ILogger<CustomFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items[FilterObjectKey] = "Please wait...";

            _logger.LogInformation("{FV}", context.HttpContext.Items[FilterObjectKey].ToString());
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Items[FilterObjectKey] = "The forecast is ready";

            _logger.LogInformation("{FV}", context.HttpContext.Items[FilterObjectKey].ToString());
        }
    }
}