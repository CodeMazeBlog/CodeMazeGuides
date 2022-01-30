using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncsInCsharp.Examples
{
    public class FuncExample
    {
        private int Sum(int a, int b)
        {
            return a + b;
        }

        public int RunExample(int a, int b)
        {
            Func<int, int, int> add = Sum;

            var result = add(a, b);

            Console.WriteLine(result);

            return result;
        }
    }
}
