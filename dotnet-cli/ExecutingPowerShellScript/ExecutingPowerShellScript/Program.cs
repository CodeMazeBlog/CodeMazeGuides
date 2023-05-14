using System.Collections.ObjectModel;
using System.Management.Automation;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ExecutingPowerShellScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessStart processStart = new ProcessStart();
            var output1 = processStart.ExecuteScript(@"C:\Users\scule\Desktop\echo.ps1");
            Console.WriteLine(output1.ToString());
            var output2 = processStart.ExecuteCommand("echo 'I am invoked using echo command!'");
            Console.WriteLine(output2.ToString());

            PowerShellClass powerShellClass= new PowerShellClass();
            var output3 = powerShellClass.ExecuteScript(@"C:\Users\scule\Desktop\echo.ps1");
            Console.WriteLine(output3.ToString());
            var output4 = powerShellClass.ExecuteCommand("Get-Date");
            Console.WriteLine(output4);
            var output5 = powerShellClass.StartProcess("notepad");
            Console.WriteLine(output5.ToString());

            PSCustomRunspace customRunspace = new();
            var output6 = customRunspace.ExecuteCommand("Get-Date");
            Console.WriteLine(output6.ToString());
            customRunspace.StartAProcess("notepad");
            var output7 = customRunspace.StartAProcess("notepad");
            Console.WriteLine(output7.ToString());
            Console.ReadLine();

        }
    }

}