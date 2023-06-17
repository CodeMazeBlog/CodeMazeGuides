using Microsoft.PowerShell.Commands;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace ExecutingPowerShellScript
{
    public class PSCustomRunspace
    {
        private readonly Runspace? _rs;

        public PSCustomRunspace()
        {
            InitialSessionState iss = InitialSessionState.Create();
            var entry = new SessionStateVariableEntry(
                "AllowedCommands", new[] { "Get-Date" }, "List of allowed commands");
            iss.Variables.Add(entry);

            var ms = new ModuleSpecification("Microsoft.PowerShell.Utility");
            iss.ImportPSModule(new[] { ms });
            var getDateCmdlet = new SessionStateCmdletEntry("Get-Date", 
                typeof(GetDateCommand), "");
            iss.Commands.Add(getDateCmdlet);
            _rs = RunspaceFactory.CreateRunspace(iss);
            _rs.Open();
        }

        public string ExecuteCommand(string command)
        {
            using var ps = PowerShell.Create();
            ps.Runspace = _rs;
            ps.AddCommand(command);
            var processes = ps.Invoke();

            return processes.First().ToString();
        }

        public bool StartProcess(string processName)
        {
            try
            {
                using (var ps = PowerShell.Create())
                {
                    ps.Runspace = _rs;
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
