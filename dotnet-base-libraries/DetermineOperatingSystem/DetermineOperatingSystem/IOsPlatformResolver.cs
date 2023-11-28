using System.Runtime.InteropServices;

namespace DetermineOperatingSystem;

public interface IOsPlatformResolver
{
    bool IsWindows();
    bool IsLinux();
    bool IsOsx();
    bool IsFreeBsd();
    bool IsPlatform(OSPlatform osPlatform);
}