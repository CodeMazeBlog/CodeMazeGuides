using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ValidateMediaTypeAttribute : ActionFilterAttribute
{
    private readonly string _expectedMediaType;

    public ValidateMediaTypeAttribute(string expectedMediaType)
    {
        _expectedMediaType = expectedMediaType;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var contentType = context.HttpContext.Request.ContentType;
        if (contentType != _expectedMediaType)
        {
            context.Result = new ContentResult
            {
                StatusCode = 415,
                ContentType = "text/plain",
                Content = $"Unsupported Media Type. Received: {contentType} Expected: {_expectedMediaType}"
            };
        }

        base.OnActionExecuting(context);
    }
}
