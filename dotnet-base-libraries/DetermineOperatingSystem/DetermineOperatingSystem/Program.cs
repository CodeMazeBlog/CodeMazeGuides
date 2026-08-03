using System.Runtime.InteropServices;
using DetermineOperatingSystem;

var myOwnOperatingSystem = OSPlatform.Create("MyOwnOperatingSystem");

var basePathResolver = new BasePathResolver(new OsPlatformResolver());
var basePath = basePathResolver.GetBasePath(myOwnOperatingSystem);
Console.WriteLine($"Base Path: {basePath}");

// From .NET 5 and later:
var isWindows = OperatingSystem.IsWindows();
var isMacOs = OperatingSystem.IsMacOS();
var isLinux = OperatingSystem.IsLinux();
Console.WriteLine($"OS is Windows: {isWindows}");
Console.WriteLine($"OS is MacOS: {isMacOs}");
Console.WriteLine($"OS is Linux: {isLinux}");