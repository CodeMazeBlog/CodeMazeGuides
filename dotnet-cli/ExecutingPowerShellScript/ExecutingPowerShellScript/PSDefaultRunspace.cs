using System.Collections.ObjectModel;
using System.Management.Automation;

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
