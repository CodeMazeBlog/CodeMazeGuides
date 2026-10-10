using Microsoft.PowerShell;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace ExecutingPowerShellScript;

public class PowerShellClass
{
    public bool ExecuteScript(string pathToScript)
    {
        var iss = InitialSessionState.CreateDefault();
        iss.ExecutionPolicy = ExecutionPolicy.Bypass;

        using var ps = PowerShell.Create(iss);
        ps.AddCommand(pathToScript).Invoke();

        return !ps.HadErrors;
    }

    public string ExecuteCommand(string command)
    {
        using var ps = PowerShell.Create();
        ps.AddCommand(command);
        var results = ps.Invoke();

        if (ps.HadErrors)
        {
            throw new InvalidOperationException(ps.Streams.Error[0].ToString());
        }

        return results.FirstOrDefault()?.ToString() ?? string.Empty;
    }

    public bool StartProcess(string processName)
    {
        using var ps = PowerShell.Create();
        ps.AddCommand("Start-Process").AddArgument(processName);
        ps.Invoke();

        return !ps.HadErrors;
    }
}
