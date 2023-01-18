using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ExecuteCliExample;

public class DotnetNativeWrapper
{
    public event OnChunkStreamHandler? OnStdOutput;
    public event OnChunkStreamHandler? OnStdErr;

    public async Task<Version> GetVersionFromScript()
    {
        var isWin = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var args = isWin ? "/c \"version.bat\"" : "-c \"./version.sh\"";
        var tool = isWin ? "cmd" : "bash";
        ProcessStartInfo startInfo = new()
        {
            FileName = tool,
            Arguments = args,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        
        var proc = Process.Start(startInfo);

        ArgumentNullException.ThrowIfNull(proc);

        string output = proc.StandardOutput.ReadToEnd();
        await proc.WaitForExitAsync();

        return Version.Parse(output);
    }

    public async Task<Version> GetVersion()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            Arguments = "--version",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        var proc = Process.Start(startInfo);

        ArgumentNullException.ThrowIfNull(proc);

        string output = proc.StandardOutput.ReadToEnd();
        await proc.WaitForExitAsync();

        return Version.Parse(output);
    }

    public async Task<bool> CreateNewProject(string projectName, string outputDir)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            Arguments = $"new console --name \"{projectName}\" --output \"{outputDir}\"",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        var proc = Process.Start(startInfo);

        ArgumentNullException.ThrowIfNull(proc);

        string output = proc.StandardOutput.ReadToEnd();
        await proc.WaitForExitAsync();

        return proc.ExitCode == 0;
    }

    public async Task ListProjects()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            Arguments = "new list",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        var proc = Process.Start(startInfo);

        ArgumentNullException.ThrowIfNull(proc);

        var stdOut = new CliEventStreamReader(proc.StandardOutput);
        var stdErr = new CliEventStreamReader(proc.StandardError);

        AttachStdOutEventHandler(stdOut);
        AttachStdErrEventHandler(stdErr);

        await proc.WaitForExitAsync();
    }

    public async Task<(int exitCode, string? error)> RunInvalidCommand()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            Arguments = "invalid command",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        var proc = Process.Start(startInfo);

        ArgumentNullException.ThrowIfNull(proc);

        string errorOutput = proc.StandardError.ReadToEnd();
        await proc.WaitForExitAsync();

        return (proc.ExitCode, errorOutput);
    }

    private void AttachStdOutEventHandler(CliEventStreamReader stdOut)
    {
        if (OnStdOutput is not null)
        {
            stdOut.OnChunkReceived += OnStdOutput;
        }
    }

    private void AttachStdErrEventHandler(CliEventStreamReader stdErr)
    {
        if (OnStdErr is not null)
        {
            stdErr.OnChunkReceived += OnStdErr;
        }
    }
}