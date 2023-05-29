using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutingPowerShellScript
{
    public class ProcessStart
    {
        public string ExecuteScript(string pathToScript)
        {
             string scriptArguments = "-ExecutionPolicy Bypass -File \"" + pathToScript + "\"";
             ProcessStartInfo processStartInfo = new ProcessStartInfo("powershell.exe", scriptArguments);
             processStartInfo.RedirectStandardOutput = true;
             processStartInfo.RedirectStandardError = true;
             using (var process = new Process())
             {
                 process.StartInfo = processStartInfo;
                 process.Start();
                 string output = process.StandardOutput.ReadToEnd();
                 string error = process.StandardError.ReadToEnd();
            
                 return output;
             }
        }       

        public string ExecuteCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "powershell.exe";
            processStartInfo.Arguments = $"-Command \"{command}\"";
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();

                return output;
            }
        }
                
    }
}
