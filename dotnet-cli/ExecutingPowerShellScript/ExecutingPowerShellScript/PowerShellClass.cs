using System.Management.Automation;

namespace ExecutingPowerShellScript
{
    public class PowerShellClass
    {
        public bool ExecuteScript(string pathToScript)
        {
            using var ps = PowerShell.Create();
            ps.AddScript(pathToScript).Invoke();
            if (ps.HadErrors)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string ExecuteCommand(string command)
        {
            using var ps = PowerShell.Create();
            ps.AddCommand(command);
            var processes = ps.Invoke();

            return processes.First().ToString();
        }

        public bool StartProcess(string processName)
        {
            using var ps = PowerShell.Create();
            ps.AddCommand("Start-Process").AddArgument(processName);
            ps.Invoke();
            if (ps.HadErrors)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
