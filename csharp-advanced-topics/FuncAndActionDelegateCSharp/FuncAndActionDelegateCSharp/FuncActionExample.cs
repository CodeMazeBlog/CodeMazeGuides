using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionCsharp
{
    public class FuncActionExample
    {
        //Does not required creation of delegate

        public void Greeting(string message)
        {
            Console.WriteLine(message);
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public void CheckDelegate()
        {
            Console.WriteLine("Results using Func and Action");
            //Action
            Action<string> say = Greeting;
            say("Hello");

            //Func 
            Func<int, int, int> calculate = Add;
            int result = calculate(2, 3);
            Console.WriteLine(result);
        }

    }
}
