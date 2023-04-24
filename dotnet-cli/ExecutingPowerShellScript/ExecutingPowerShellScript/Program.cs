using System.Collections.ObjectModel;
using System.Management.Automation;

namespace ExecutingPowerShellScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PSDefaultRunspace defaultRunspace = new();
            var processes=defaultRunspace.GetRunningProcesses();
            PrintToConsole(processes);

            var detailedProcesses= defaultRunspace.GetRunningProcessesDetails();
            PrintToConsole(detailedProcesses);
            defaultRunspace.StartAProcess("notepad");

            PSCustomRunspace customRunspace = new();
            var processStarted= customRunspace.StartAProcess("notepad");
            if (!processStarted)
            {
                Console.WriteLine("This is a custom runspace that can only run Get-Process command");
            }

            Console.ReadLine();

            void PrintToConsole(Collection<PSObject> results)
            {
                foreach (PSObject obj in results)
                {
                    Console.WriteLine(obj.ToString());
                }
            }
        }
       

    }

}