using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace ExecutingPowerShellScript
{
    public class PSDefaultRunspace
    {
        public Collection<PSObject> GetRunningProcesses()
        {
            using (var ps = PowerShell.Create())
            {
                ps.AddCommand("Get-Process");
                var processes = ps.Invoke();

                return processes;
            }
        }
        public Collection<PSObject> GetRunningProcessesDetails()
        {
            using (var ps = PowerShell.Create())
            {
                ps.AddCommand("Get-Process").AddCommand("Select-Object").AddArgument(new[] { "Name", "CPU" });
                var processes = ps.Invoke();

                return processes;
            }
        }
        public bool StartAProcess(string processName)
        {
            try
            {
                using (var ps = PowerShell.Create())
                {
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
