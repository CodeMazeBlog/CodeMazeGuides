using System.Runtime.InteropServices;
using DetermineOperatingSystem;

// For versions of .NET Framework and .NET Core prior to .NET 5:
OSPlatform myOwnOperatingSystem = OSPlatform.Create("MyOwnOperatingSystem");

var basePathResolver = new BasePathResolver(new OsPlatformResolver());
string basePath = basePathResolver.GetBasePath(myOwnOperatingSystem);

// From .NET 5 and later:
bool isWindows = OperatingSystem.IsWindows();
bool isMacOs = OperatingSystem.IsMacOS();
bool isLinux = OperatingSystem.IsLinux();