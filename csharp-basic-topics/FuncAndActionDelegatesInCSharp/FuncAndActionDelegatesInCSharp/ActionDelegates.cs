using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegatesInCSharp
{
    public class ActionDelegates
    {
        public static void ActionDelegate()
        {
            Action<string> greetMethod = GreetUser;
            static void GreetUser(string name)
            {
                Console.WriteLine($"Hello, {name}");
            }
            greetMethod("Code Maze"); //Output: Hello, Code Maze
        }

        public static void ActionDelegateMultipleParameters()
        {
            Action<string, DateTime> greetMethod = GreetUser;
            static void GreetUser(string name, DateTime date)
            {
                Console.WriteLine($"Hello, {name} @ {date:dd/MM/yyyy HH:mm}");
            }
            greetMethod("Code Maze", DateTime.Now); //Output: Hello, Code Maze @ 04/06/2023 11:32
        }
    }
}
