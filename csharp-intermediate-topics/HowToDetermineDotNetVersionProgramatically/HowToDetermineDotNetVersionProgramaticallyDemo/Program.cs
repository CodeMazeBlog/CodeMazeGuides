using static HowToDetermineDotNetVersionProgramatically.DotNetAssemblyVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetTargetFrameworkName;
using static HowToDetermineDotNetVersionProgramatically.DotNetClrVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetFrameworkDescription;
using static HowToDetermineDotNetVersionProgramatically.DotNetCoreVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetRuntimeVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetSdkVersion;

Console.WriteLine(GetEnvironmentVersion());

Console.WriteLine(GetFrameworkDescription());
var parts = GetFrameworkDescription().Split(" ");
var namePart = parts[0];
Console.WriteLine(namePart);
var versionPart = parts[1];
Console.WriteLine(versionPart);

Console.WriteLine(GetTargetFrameworkName());

var path = Path.Combine(AppContext.BaseDirectory, "HowToDetermineDotNetVersionProgramaticallyDemo.dll");
Console.WriteLine(GetAssemblyDotNetVersion(path));

Console.WriteLine(GetNetCoreVersion());

Console.WriteLine(GetDotNetSdkVersionsInstalled());
foreach (var (sdkVersion, installPath) in GetInstalledSdkVersions())
{
    Console.WriteLine($"SDK version: {sdkVersion} Install path: {installPath}");
}

Console.WriteLine(GetDotNetRuntimeVersionsInstalled());
foreach (var (name, version, installPath) in GetInstalledDotNetRuntimeVersions())
{
    Console.WriteLine($"Runtime name: {name} Version: {version} Install path: {installPath}");
}

// output on .NET 10.0.10, Windows
// 10.0.10
// .NET 10.0.10
// .NET
// 10.0.10
// .NETCoreApp,Version=v10.0
// 10.0.0.0
// 10.0.10
// ...
// 10.0.302 [C:\Program Files\dotnet\sdk]
// ...
// SDK version: 10.0.302 Install path: [C:\Program Files\dotnet\sdk]
// ...
// Microsoft.NETCore.App 10.0.10 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
// ...
// Runtime name: Microsoft.NETCore.App Version: 10.0.10 Install path: [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
// ...
