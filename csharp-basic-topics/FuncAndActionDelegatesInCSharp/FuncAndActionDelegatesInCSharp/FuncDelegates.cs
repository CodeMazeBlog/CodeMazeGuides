using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegatesInCSharp
{
    public class FuncDelegates
    {
        public static void FuncDelegate()
        {
            Func<string, DateTime, string> greetMethod = GetGreetUser;
            static string GetGreetUser(string name, DateTime date)
            {
                return $"Hello, {name} @ {date:dd/MM/yyyy HH:mm}";
            }
            var greetResult = greetMethod("Code Maze", DateTime.Now);
            Console.WriteLine(greetResult); //Output: Hello, Code Maze @ 04/06/2023 11:32
        }
    }
}
