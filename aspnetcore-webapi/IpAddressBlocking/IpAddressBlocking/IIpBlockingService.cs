using System.Net;

namespace IpAddressBlocking;

public interface IIpBlockingService
{
    bool IsBlocked(IPAddress ipAddress);
}
