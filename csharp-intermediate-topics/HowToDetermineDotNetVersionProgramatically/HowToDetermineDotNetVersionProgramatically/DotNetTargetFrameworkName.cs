using System.Reflection;
using System.Runtime.Versioning;

namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetTargetFrameworkName
{
    public static string GetTargetFrameworkName()
    {
        return Assembly
            .GetEntryAssembly()?
            .GetCustomAttribute<TargetFrameworkAttribute>()?
            .FrameworkName ?? "";
    }
}
