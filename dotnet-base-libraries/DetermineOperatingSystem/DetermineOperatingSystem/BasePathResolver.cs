using System.Runtime.InteropServices;

namespace DetermineOperatingSystem;

public class BasePathResolver
{
    private readonly IOsPlatformResolver _osPlatformResolver;

    public BasePathResolver(IOsPlatformResolver osPlatformResolver)
    {
        _osPlatformResolver = osPlatformResolver;
    }

    public string GetBasePath(OSPlatform? otherPlatform = null)
    {
        var basePath = string.Empty;

        if (_osPlatformResolver.IsWindows())
        {
            basePath = "C:\\MyApp\\";
        }
        else if (_osPlatformResolver.IsLinux() || _osPlatformResolver.IsOsx())
        {
            basePath = "/MyApp/";
        }
        else if (_osPlatformResolver.IsFreeBsd() || (otherPlatform.HasValue && _osPlatformResolver.IsPlatform(otherPlatform.Value)))
        {
            throw new NotSupportedException();
        }

        return basePath;
    }
}