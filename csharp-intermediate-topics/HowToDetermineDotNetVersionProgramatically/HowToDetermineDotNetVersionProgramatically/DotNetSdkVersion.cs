namespace HowToDetermineDotNetVersionProgramatically;

public static class DotNetSdkVersion
{
    public static string GetDotNetSdkVersionsInstalled()
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

    public static ICollection<(string version, string installPath)> GetInstalledSdkVersions()
    {
        return GetDotNetSdkVersionsInstalled()
            .Split(Environment.NewLine)
            .Select(x => x.Split(' '))
            .Where(x => x.Length == 2)
            .Select(x => (version: x[0], installPath: x[1]))
            .ToArray();
    }
}
