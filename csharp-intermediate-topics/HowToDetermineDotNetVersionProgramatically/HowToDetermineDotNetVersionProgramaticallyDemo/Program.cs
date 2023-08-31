using static HowToDetermineDotNetVersionProgramatically.DotNetAssemblyVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetTargetFrameworkName;
using static HowToDetermineDotNetVersionProgramatically.DotNetClrVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetFrameworkDescription;
using static HowToDetermineDotNetVersionProgramatically.DotNetCoreVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetRuntimeVersion;
using static HowToDetermineDotNetVersionProgramatically.DotNetSdkVersion;

var path = "HowToDetermineDotNetVersionProgramaticallyDemo.dll";
Console.WriteLine(GetAssemblyDotNetVersion(path));

Console.WriteLine(GetTargetFrameworkName());

Console.WriteLine(GetEnvironmentVersion());

Console.WriteLine(GetFrameworkDescription());
var parts = GetFrameworkDescription().Split(" ");
var namePart = parts[0];
Console.WriteLine(namePart);
var versionPart = parts[1];
Console.WriteLine(versionPart);

Console.WriteLine(GetNetCoreVersion());

Console.WriteLine(GetDotNetSdkVersionsInstalled());
static ICollection<(string version, string installPath)> GetInstalledSdkVersionsCollection()
{
    return GetDotNetSdkVersionsInstalled()
        .Split(Environment.NewLine)
        .Select(x => x.Split(' '))
        .Where(x => x.Length == 2)
        .Select(x => (version: x[0], installPath: x[1]))
        .ToArray();
}
foreach (var (sdkVersion, installPath) in GetInstalledSdkVersionsCollection())
{
    Console.WriteLine($"SDK version: {sdkVersion} Install path: {installPath}");
}

Console.WriteLine(GetDotNetRuntimeVersionsInstalled());
static ICollection<(string name, string version, string installPath)>
    GetInstalledDotNetRuntimeVersionsCollection()
{
    return GetDotNetRuntimeVersionsInstalled()
        .Split(Environment.NewLine)
        .Select(x => x.Split(' '))
        .Where(x => x.Length == 3)
        .Select(x => (name: x[0], version: x[1], installPath: x[2]))
        .ToArray();
}
foreach (var (name, version, installPath) in GetInstalledDotNetRuntimeVersionsCollection())
{
    Console.WriteLine($"Runtime name: {name} Version: {version} Install path: {installPath}");
}

Console.ReadLine();

// output
// 7.0.0.0
// .NETCoreApp,Version=v7.0
// 7.0.0
// .NET 7.0.0
// .NET
// 7.0.0
// 7.0.0

// ...
// 7.0.100 [/usr/local/share/dotnet/sdk]
// ...

// ...
// SDK version: 7.0.100 Install path: [/usr/local/share/dotnet/sdk]
// ...

// ...
// Microsoft.NETCore.App 7.0.1 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
// ...

// ...
// Runtime name: Microsoft.NETCore.App
// Version: 7.0.1
// Install path: [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
// ...
