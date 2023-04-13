using Microsoft.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace ExecutingPowerShellScript
{
    public class PSCustomRunspace
    {
        private static Runspace rs;
        public PSCustomRunspace()
        {
            InitialSessionState iss = InitialSessionState.Create();
            SessionStateVariableEntry entry = new SessionStateVariableEntry
            (
                "AllowedCommands", new[] { "Get-Process" }, "List of allowed commands"
            );
            iss.Variables.Add(entry);
            ModuleSpecification ms = new ModuleSpecification("Microsoft.PowerShell.Management");
            iss.ImportPSModule(new[] { ms });
            SessionStateCmdletEntry getProcessCmdlet = new SessionStateCmdletEntry
            (
                "Get-Process", typeof(System.Diagnostics.Process), ""
            );
            iss.Commands.Add(getProcessCmdlet);
            rs = RunspaceFactory.CreateRunspace(iss);
            rs.Open();
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
