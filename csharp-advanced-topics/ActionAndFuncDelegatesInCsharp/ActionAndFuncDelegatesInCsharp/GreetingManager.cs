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
            _consoleWriter.WriteLine($"Hi {fullName}! I hope you are doing great! Welcome to CodeMaze!");
        }
        public void InformalGreeting(string name, string family)
        {
            string fullName = string.IsNullOrEmpty(name) && string.IsNullOrEmpty(family)
                 ? $"" : (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family) ? $"{family}"
                 : (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family) ? $"{name} {family}" : $"{name}"));
            _consoleWriter.WriteLine($"Hey {fullName}! How is everything?");
        }
    }
}
