using System.Net.Sockets;
using System.Net;

namespace RemoteHostIpAddress
{
    public class RemoteHostService : IRemoteHostService
    {
        public IPAddress GetRemoteHostIpAddressUsingRemoteIpAddress(HttpContext httpContext)
        {
            return httpContext.Connection.RemoteIpAddress;
        }

        public IPAddress? GetRemoteHostIpAddressUsingXForwardedFor(HttpContext httpContext)
        {
            IPAddress? remoteIpAddress = null;
            var forwardedFor = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (!string.IsNullOrEmpty(forwardedFor))
            {
                var ips = forwardedFor.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(s => s.Trim());

                foreach (var ip in ips)
                {
                    if (IPAddress.TryParse(ip, out var address) &&
                        (address.AddressFamily == AddressFamily.InterNetwork || address.AddressFamily == AddressFamily.InterNetworkV6))
                    {
                        remoteIpAddress = address;
                        break;
                    }
                }
            }

            return remoteIpAddress;
        }

        public IPAddress? GetRemoteHostIpAddressUsingXRealIp(HttpContext httpContext)
        {
            IPAddress? remoteIpAddress = null;
            var xRealIpHeaderValue = httpContext.Request.Headers["X-Real-IP"].FirstOrDefault();

            if (IPAddress.TryParse(xRealIpHeaderValue, out var address))
            {
                var isValidIP = (address.AddressFamily == AddressFamily.InterNetwork || address.AddressFamily == AddressFamily.InterNetworkV6);
                if (isValidIP)
                {
                    remoteIpAddress = address;
                }
            }

            return remoteIpAddress;
        }
    }
}
