using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncsInCsharp.Examples
{
    public class ActionExample
    {
        private void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public void RunExample()
        {
            Action<string> logger = LogToConsole;

            logger("Hello World");
        }
    }
}
