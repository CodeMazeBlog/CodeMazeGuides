using System.Diagnostics;

var startInfo = new ProcessStartInfo()
{
    FileName = "ping",
    Arguments = "256.256.256.256"
};

using (Process process = Process.Start(startInfo))
{
    process.WaitForExit();
    int exitCode = process.ExitCode;

    Console.WriteLine($"Exit code: {exitCode}");

    if (exitCode != 0)
    {
        // The ping command has different command returns different error codes across different operating systems.
        exitCode = 1;
    }

    Environment.Exit(exitCode);
}