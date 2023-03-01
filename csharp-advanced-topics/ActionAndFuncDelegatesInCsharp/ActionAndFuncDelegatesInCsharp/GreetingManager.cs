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
            _consoleWriter.WriteLine($"Hi {name} {family}! I hope you are doing great! Welcome to CodeMaze!");
        }
        public void InformalGreeting(string name, string family)
        {
            _consoleWriter.WriteLine($"Hey {name} {family}! How is everything?");
        }
    }
}
