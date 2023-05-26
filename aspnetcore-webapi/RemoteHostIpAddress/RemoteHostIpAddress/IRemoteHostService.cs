using System.Net;

namespace RemoteHostIpAddress
{
    public interface IRemoteHostService
    {
        public IPAddress? GetRemoteHostIpAddressUsingRemoteIpAddress(HttpContext httpContext);

        public IPAddress? GetRemoteHostIpAddressUsingXForwardedFor(HttpContext httpContext);

        public IPAddress? GetRemoteHostIpAddressUsingXRealIp(HttpContext httpContext);
    }
}
