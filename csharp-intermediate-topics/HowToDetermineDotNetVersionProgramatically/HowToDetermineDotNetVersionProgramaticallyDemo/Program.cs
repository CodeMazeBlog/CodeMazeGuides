using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;

static string GetAssemblyDotNetVersion(string assemblyFile)
{
    var assembly = Assembly.LoadFrom(assemblyFile);
    var references = assembly.GetReferencedAssemblies();
    var version = references.FirstOrDefault(x => x.Name.StartsWith("System.Runtime"));

    return version?.Version?.ToString() ?? "";
}

// Potential use case
// var path = "path/to/the dotnet assembly in question";
var path = "HowToDetermineDotNetVersionProgramaticallyDemo.dll";
Console.WriteLine(GetAssemblyDotNetVersion(path));
// output for .NET 7.x:
// 7.x



static string GetTargetFrameworkName()
{
    return Assembly
        .GetEntryAssembly()?
        .GetCustomAttribute<TargetFrameworkAttribute>()?
        .FrameworkName;
}

// Potential use case
Console.WriteLine(GetTargetFrameworkName());
// output for .NETFramework 4.x:
// .NET Framework,Version=v4…
// output for .NET Core 5.x:
// .NETCoreApp,Version=v5…



static string GetEnvironmentVersion() => Environment.Version.ToString();

// Potential use case
Console.WriteLine(GetEnvironmentVersion());
// output for .NET 7.x:
// 7.x



static string GetFrameworkDescription() => System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;

// Potential use case
Console.WriteLine(GetFrameworkDescription());
// output for .NET 7.0:
// .NET 7.0

var parts = GetFrameworkDescription().Split(" ");
var namePart = parts[0];
Console.WriteLine(namePart);
// output:
// .NET
var versionPart = parts[1];
Console.WriteLine(versionPart);
// output:
// 7.0



static string GetNetCoreVersion()
{
    var assembly = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly;
    var assemblyPath = assembly.Location.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
    int netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
    if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
        return assemblyPath[netCoreAppIndex + 1];
    return "";
}

// Potential use case
Console.WriteLine(GetNetCoreVersion());
// output for .NET Core 3.1.0:
// 3.1.0



static string GetDotNetSdkVersionsInstalled()
{
    var process = new Process();
    process.StartInfo.FileName = "dotnet";
    process.StartInfo.Arguments = "--list-sdks";
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    var output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    return output;
}

// Potential use case
Console.WriteLine(GetDotNetSdkVersionsInstalled());
// output on mac:
// ...
// 7.0.100 [/usr/local/share/dotnet/sdk]
// ...

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
// output on mac:
// ...
// SDK version: 7.0.100 Install path: [/usr/local/share/dotnet/sdk]
// ...



static string GetDotNetRuntimeVersionsInstalled()
{
    var process = new Process();
    process.StartInfo.FileName = "dotnet";
    process.StartInfo.Arguments = "--list-runtimes";
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    var output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    return output;
}

// Potential use case
Console.WriteLine(GetDotNetRuntimeVersionsInstalled());
// output on mac:
// ...
// Microsoft.NETCore.App 7.0.1 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
// ...

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
// output on mac:
// ...
// Runtime name: Microsoft.NETCore.App
// Version: 7.0.1
// Install path: [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]
// ...

Console.ReadLine();
