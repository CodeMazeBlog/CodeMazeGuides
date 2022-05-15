using System.Net;

namespace IpAddressBlocking;

public class IpBlockMiddelware
{
    private readonly RequestDelegate _next;
    private readonly IIpBlacklistService _blacklistService;

    public IpBlockMiddelware(RequestDelegate next, IIpBlacklistService blacklistService)
    {
        _next = next;
        _blacklistService = blacklistService;
    }

    public async Task Invoke(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress;

        var isBlacklisted = _blacklistService.IsBlacklisted(remoteIp!);

        if (isBlacklisted)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return;
        }

        await _next.Invoke(context);
    }
}
