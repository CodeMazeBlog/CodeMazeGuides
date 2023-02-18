using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionCsharp
{
    public class DelegateExample
    {
        public delegate void Say(string message);
        public delegate int Calculate(int x, int y);
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
            Console.WriteLine("Results using delegates");
            //delegate with void type method
            Say say = Greeting;
            say("Hello");

            //delegate with return type method
            Calculate calculate = Add;
            int result = calculate(2, 3);
            Console.WriteLine(result);
        }

    }
}
