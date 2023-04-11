using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EFCoreJsonInEntityField.Models;

namespace EFCoreJsonInEntityField.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            var statusCode = HttpStatusCode.InternalServerError;            
            var exceptionString = new ErrorResponseData()
            {
                StatusCode = (int)statusCode,
                Message = context.Exception.Message,
                Path = context.Exception.StackTrace
            };

            context.Result = new JsonResult(exceptionString);
        }
    }
}
