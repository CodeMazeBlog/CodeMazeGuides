using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public class DelegateExample
    {
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public void GreetPerson(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
