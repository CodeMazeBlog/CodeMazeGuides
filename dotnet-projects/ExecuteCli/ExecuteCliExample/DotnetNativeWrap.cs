using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ExecuteCliExample;

public class DotnetNativeWrapper
{
    public event OnChunkStreamHandler? OnStdOutput;
    public event OnChunkStreamHandler? OnStdErr;

    public async Task<string> GetInfo()
    {
        var isWin = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var args = isWin ? "/c \"info.bat\"" : "-c \"./info.sh\"";
        var tool = isWin ? "cmd" : "bash";
        ProcessStartInfo startInfo = new()
        {
            FileName = tool,
            Arguments = args,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        
        var proc = Process.Start(startInfo);

        ArgumentNullException.ThrowIfNull(proc);

        string output = proc.StandardOutput.ReadToEnd();
        await proc.WaitForExitAsync();

        return output;
    }

    public async Task<Version> GetVersion()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            Arguments = "--version",
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

    public async Task ListProjects()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            Arguments = "new list",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        var proc = Process.Start(startInfo);

        ArgumentNullException.ThrowIfNull(proc);

        var stdOut = new CliEventStreamer(proc.StandardOutput);
        var stdErr = new CliEventStreamer(proc.StandardError);

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

    private void AttachStdOutEventHandler(CliEventStreamer stdOut)
    {
        if (OnStdOutput is not null)
        {
            stdOut.OnChunkReceived += OnStdOutput;
        }
    }

    private void AttachStdErrEventHandler(CliEventStreamer stdErr)
    {
        if (OnStdErr is not null)
        {
            stdErr.OnChunkReceived += OnStdErr;
        }
    }
}