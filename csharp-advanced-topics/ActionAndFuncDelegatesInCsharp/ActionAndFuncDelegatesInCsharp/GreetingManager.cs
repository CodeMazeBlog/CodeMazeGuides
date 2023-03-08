using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class GreetingManager
    {
        private IConsoleWriter _consoleWriter;
        
        public GreetingManager(IConsoleWriter consolewriter)
        {
            _consoleWriter = consolewriter;
        }

        public void FormalGreeting(string name, string family)
        {
            string fullName = string.IsNullOrEmpty(name) && string.IsNullOrEmpty(family)
                ? $"" : (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family) ? $"{family}"
                : (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family) ? $"{name} {family}" : $"{name}"));
            
            _consoleWriter.WriteLine($"Hi {fullName}!\r\nWelcome to Code Maze, your .NET learning website!" 
                +$"\r\nWhatever you want to learn, we are here to help!\r\nLet's start...\r\n\r\n");
        }

        public void InformalGreeting(string name, string family)
        {
            string fullName = string.IsNullOrEmpty(name) && string.IsNullOrEmpty(family)
                 ? $"" : (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family) ? $"{family}"
                 : (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family) ? $"{name} {family}" : $"{name}"));
            
            _consoleWriter.WriteLine($"Hey {fullName}!\r\nIt's Code Maze here!"+
                $"\r\nWhatever you want to learn, we are here to help!\r\nLet's have fun :)"
                );
        }
    }
}
