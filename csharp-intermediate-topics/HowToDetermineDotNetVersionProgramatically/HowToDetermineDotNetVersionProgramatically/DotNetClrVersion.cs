using System.Reflection;

namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetClrVersion
{
    public static string GetEnvironmentVersion()
    {
        return Environment.Version.ToString();
    }
    
    public static string GetAssemblySupportedMinimumClrVersion(string dllPath)
    {
        var assembly = Assembly.LoadFrom(dllPath);
        var imageVersion = assembly.ImageRuntimeVersion;
        
        return imageVersion;
    }
}
