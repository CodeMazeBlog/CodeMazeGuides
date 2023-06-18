namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetAssemblyVersion
{
    public static string GetAssemblyDotNetVersion(string assemblyFile)
    {
        var fvi = FileVersionInfo.GetVersionInfo(assemblyFile);
        return fvi.FileVersion ?? "";
    }
}