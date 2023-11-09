using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;

namespace EFCoreJsonInEntityField.Filters
{
    public class RestrictPatchOperationsAttribute<T> : ActionFilterAttribute
        where T : class
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var patchOperations = context.ActionArguments.FirstOrDefault(a => a.Value is JsonPatchDocument<T>).Value as JsonPatchDocument<T>;

            if (patchOperations != null)
            {
                foreach (Operation operation in patchOperations.Operations)
                {
                    if (operation.op != "replace")
                    {
                        context.Result = new BadRequestObjectResult($"Patch operation {operation.op} not allowed.");
                        return;
                    }
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
