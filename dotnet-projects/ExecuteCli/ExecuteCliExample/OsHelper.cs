using System.Runtime.InteropServices;

namespace ExecuteCliExample;

public static class OsHelper
{
    public static readonly OSPlatform Platform = GetOSPlatform();

    public static bool IsUnix => Platform == OSPlatform.Linux ||
                                    Platform == OSPlatform.OSX;
    public static readonly bool IsWindows = !IsUnix;

    private static OSPlatform GetOSPlatform()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return OSPlatform.OSX;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return OSPlatform.Linux;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return OSPlatform.Windows;

        throw new Exception("Unsupported platform type");
    }
}