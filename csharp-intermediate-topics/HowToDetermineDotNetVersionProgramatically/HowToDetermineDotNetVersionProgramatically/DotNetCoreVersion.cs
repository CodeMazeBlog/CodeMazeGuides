using System.Runtime;

namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetCoreVersion
{
    public static string GetNetCoreVersion()
    {
        var assembly = typeof(GCSettings).Assembly;
        var assemblyPath = assembly.Location.Split(['/', '\\'], StringSplitOptions.RemoveEmptyEntries);
        var netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
        
        if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
            return assemblyPath[netCoreAppIndex + 1];
        
        return "";
    }
}
