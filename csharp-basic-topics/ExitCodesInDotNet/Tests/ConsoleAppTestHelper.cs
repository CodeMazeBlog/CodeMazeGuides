using System.Diagnostics;
using System.Reflection;

namespace Tests;

public static class ConsoleAppTestHelper
{
    public static int RunConsoleAppAndGetExitCode(string targetAssembly, string args = null)
    {
        var path = GetConsoleAppPath(targetAssembly);
        var exitCode = RunProcessAndGetExitCode(path, args);
        return exitCode;
    }

    public static string GetConsoleAppPath(string targetAssemlyName)
    {
        // Get the path to the current executing assembly
        string assemblyLocation = Assembly.GetExecutingAssembly().Location;
        // Get the directory where the assembly is located
        string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
        // Combine the directory with the name of your console application executable
        return Path.Combine(assemblyDirectory, $"{targetAssemlyName}.dll");
    }

    public static int RunProcessAndGetExitCode(string appPath, string args = "")
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = $"dotnet",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            Arguments = $"{appPath} {args}"
        };

        using var process = Process.Start(processInfo);
        process.WaitForExit();
        return process.ExitCode;
    }
}
