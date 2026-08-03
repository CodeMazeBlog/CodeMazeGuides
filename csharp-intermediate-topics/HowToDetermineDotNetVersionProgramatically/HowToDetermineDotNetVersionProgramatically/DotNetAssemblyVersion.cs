using System.Reflection;

namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetAssemblyVersion
{
    public static string GetAssemblyDotNetVersion(string assemblyFile)
    {
        var assembly = Assembly.LoadFrom(assemblyFile);
        var references = assembly.GetReferencedAssemblies();
        var version = references.FirstOrDefault(x => x.Name == "System.Runtime");

        return version?.Version?.ToString() ?? "";
    }
}
