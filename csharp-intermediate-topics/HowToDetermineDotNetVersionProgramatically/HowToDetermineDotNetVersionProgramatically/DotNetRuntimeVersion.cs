namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetRuntimeVersion
{
    public static string GetDotNetRuntimeVersionsInstalled()
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

    public static ICollection<(string name, string version, string installPath)>
        GetInstalledDotNetRuntimeVersions()
    {
        return GetDotNetRuntimeVersionsInstalled()
            .Split(Environment.NewLine)
            .Select(x => x.Split(' '))
            .Where(x => x.Length == 3)
            .Select(x => (name: x[0], version: x[1], installPath: x[2]))
            .ToArray();
    }
}
