using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    public class ActionDemo
    {
        public string nameToDisplay = "Code Maze";
        public void RunAction()
        {
            Action<string> displayName = delegate (string name)
            {
                name = name.ToUpper();
                Console.WriteLine($"Hello, {name}!");
            };

            displayName(nameToDisplay);
        }
    }
}
