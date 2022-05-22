using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IpAddressBlocking;

public class IpBlockActionFilter : ActionFilterAttribute
{
    private readonly IIpBlockingService _ipBlockingService;

    public IpBlockActionFilter(IIpBlockingService ipBlockingService)
    {
        _ipBlockingService = ipBlockingService;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var remoteIp = context.HttpContext.Connection.RemoteIpAddress;

        var isBlocked = _ipBlockingService.IsBlocked(remoteIp!);

        if (isBlocked)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

        base.OnActionExecuting(context);
    }
}
