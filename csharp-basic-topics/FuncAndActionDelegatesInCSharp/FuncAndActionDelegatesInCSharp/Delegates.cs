using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegatesInCSharp
{
    public class Delegates
    {
        delegate void Greet(string name);

        public static void Delegate()
        {
            static void GreetUser(string name)
            {
                Console.WriteLine($"Hello, {name}");
            }
            Greet greetMethod = GreetUser;
            greetMethod("Code Maze"); //Output: Hello, Code Maze
        }
    }
}
