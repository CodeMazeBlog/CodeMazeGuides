using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegate.Func
{
    public class FuncDelegateExample
    {
        public static void FuncDelegate()
        {
            Func<int, int, int> add = (a, b) =>
            {
                return a + b;
            };

            int result = add(5, 3);
            Console.WriteLine("The result of adding 5 and 3 is: " + result);
        }
    }
}
