using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegatesInCSharp
{
    public class LambdaExpressions
    {
        public static void LambdaExpression()
        {
            Func<string, string> greetExpression = (name) => $"Hello, {name}";
            Console.WriteLine(greetExpression("Code Maze")); //Output: Hello, Code Maze
        }

        public static void LambdaExpressionsAsParameters()
        {
            static void PrintGreet(string name, Func<string, string> greetFunc)
            {
                Console.WriteLine(greetFunc(name));
            }
            PrintGreet("Code Maze", (name) => $"Hello, {name}"); //Output: Hello, Code Maze
        }
    }
}
