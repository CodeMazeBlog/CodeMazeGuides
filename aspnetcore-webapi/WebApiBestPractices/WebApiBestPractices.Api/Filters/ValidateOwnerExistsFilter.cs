using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiBestPractices.Application.Services;

namespace WebApiBestPractices.Api.Filters;

public class ValidateOwnerExistsFilter(IOwnerService ownerService) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.TryGetValue("id", out var value) && value is Guid id)
        {
            var owner = await ownerService.GetByIdAsync(id, context.HttpContext.RequestAborted);
            if (owner is null)
            {
                context.Result = new NotFoundResult();
                return;
            }
        }

        await next();
    }
}
