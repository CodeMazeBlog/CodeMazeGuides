using System.Diagnostics;

namespace ExecutingPowerShellScript;

public class ProcessStart
{
    public async Task<PowerShellResult> ExecuteScriptAsync(string pathToScript)
    {
        var processStartInfo = new ProcessStartInfo("pwsh")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        processStartInfo.ArgumentList.Add("-ExecutionPolicy");
        processStartInfo.ArgumentList.Add("Bypass");
        processStartInfo.ArgumentList.Add("-File");
        processStartInfo.ArgumentList.Add(pathToScript);

        using var process = new Process { StartInfo = processStartInfo };
        process.Start();

        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();
        await Task.WhenAll(outputTask, errorTask);
        await process.WaitForExitAsync();

        return new PowerShellResult(process.ExitCode, outputTask.Result, errorTask.Result);
    }

    public async Task<PowerShellResult> ExecuteCommandAsync(string command)
    {
        var processStartInfo = new ProcessStartInfo("pwsh")
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        processStartInfo.ArgumentList.Add("-Command");
        processStartInfo.ArgumentList.Add(command);

        using var process = new Process { StartInfo = processStartInfo };
        process.Start();

        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();
        await Task.WhenAll(outputTask, errorTask);
        await process.WaitForExitAsync();

        return new PowerShellResult(process.ExitCode, outputTask.Result, errorTask.Result);
    }
}
