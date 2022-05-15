using Microsoft.Extensions.Options;
using System.Net;

namespace IpAddressBlocking;

public class IpBlacklistService : IIpBlacklistService
{
    private readonly List<string> _blacklist;

    public IpBlacklistService(IConfiguration configuration)
    {
        var ipBlacklist = configuration.GetValue<string>("IpBlacklist");
        _blacklist = ipBlacklist.Split(',').ToList();
    }

    public bool IsBlacklisted(IPAddress ipAddress) => _blacklist.Contains(ipAddress.ToString());
}
