using System.Net;

namespace IpAddressBlocking;

public interface IIpBlacklistService
{
    bool IsBlacklisted(IPAddress ipAddress);
}
