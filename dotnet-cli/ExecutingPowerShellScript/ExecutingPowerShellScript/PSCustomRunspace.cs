using Microsoft.PowerShell.Commands;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace ExecutingPowerShellScript
{
    public class PSCustomRunspace
    {
        private static Runspace? rs;

        public PSCustomRunspace()
        {
            InitialSessionState iss = InitialSessionState.Create();
            SessionStateVariableEntry entry = new SessionStateVariableEntry(
                "AllowedCommands", new[] { "Get-Date" }, "List of allowed commands");
            iss.Variables.Add(entry);

            ModuleSpecification ms = new ModuleSpecification("Microsoft.PowerShell.Utility");
            iss.ImportPSModule(new[] { ms });
            SessionStateCmdletEntry getDateCmdlet = new SessionStateCmdletEntry(
                "Get-Date", typeof(Microsoft.PowerShell.Commands.GetDateCommand), "");
            iss.Commands.Add(getDateCmdlet);

            rs = RunspaceFactory.CreateRunspace(iss);
            rs.Open();
        }

        public string ExecuteCommand(string command)
        {
            using (var ps = PowerShell.Create())
            {
                ps.Runspace = rs;
                ps.AddCommand(command);
                var processes = ps.Invoke();
                return processes.First().ToString();
            }
        }

        public bool  StartAProcess(string processName)
        {
            try
            {
                using (var ps = PowerShell.Create())
                {
                    ps.Runspace = rs;
                    ps.AddCommand("Start-Process").AddArgument(processName);
                    ps.Invoke();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
