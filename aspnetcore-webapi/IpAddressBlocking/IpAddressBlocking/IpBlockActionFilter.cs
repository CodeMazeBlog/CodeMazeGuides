using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IpAddressBlocking;

public class IpBlockActionFilter : ActionFilterAttribute
{
    private readonly IIpBlacklistService _blacklistService;

    public IpBlockActionFilter(IIpBlacklistService blacklistService)
    {
        _blacklistService = blacklistService;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var remoteIp = context.HttpContext.Connection.RemoteIpAddress;

        var isBlacklisted = _blacklistService.IsBlacklisted(remoteIp!);

        if (isBlacklisted)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

        base.OnActionExecuting(context);
    }
}
