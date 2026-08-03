using System.Runtime.InteropServices;

namespace DetermineOperatingSystem;

public class OsPlatformResolver : IOsPlatformResolver
{
    public bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    public bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    public bool IsOsx() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
    public bool IsFreeBsd() => RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);
    public bool IsPlatform(OSPlatform osPlatform) => RuntimeInformation.IsOSPlatform(osPlatform);
}