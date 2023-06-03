using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegate
{
    public static class ActionSample
    {

        static Action<string> MorningGreetings = (name) => { Console.WriteLine($"Good Morning, {name}"); };

        static Action<string> AfternoonGreetings = (name) => { Console.WriteLine($"Good Afternoon, {name}"); };

        static Action<string, string> GreetingsWithTilte = (name, title) => { Console.WriteLine($"Hello, {title} {name}"); };
        public static void GreetUser(string name, string timeOfDay)
        {
            if (timeOfDay == "Morning")
            {
                MorningGreetings(name);
            }
            if (timeOfDay == "Afternoon")
            {
                AfternoonGreetings(name);
            }
        }
    }
}
