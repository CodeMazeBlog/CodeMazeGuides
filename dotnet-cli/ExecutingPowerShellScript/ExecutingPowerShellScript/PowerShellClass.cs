using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace ExecutingPowerShellScript
{
    public class PowerShellClass
    {
        public bool ExecuteScript(string pathToScript)
        {
            PowerShell ps = PowerShell.Create();
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
            using (var ps = PowerShell.Create())
            {
                ps.AddCommand(command);
                var processes = ps.Invoke();
                
                return processes.First().ToString();
                
            }
        }

        public bool StartProcess(string processName)
        {
            using (var ps = PowerShell.Create())
            {
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
}
