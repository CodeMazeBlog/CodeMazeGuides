using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    public class FuncDemo
    {
        // Func Declaration ( with anaonymous method)
        public Func<int, int, int> intMultiplyFunc = delegate (int a, int b)
        {
            return a * b;
        };

        public int value1 = 15;
        public int value2 = 1;
        public void RunFunc()
        {
            int intMultResult = intMultiplyFunc(value1, value2);
            Console.WriteLine(intMultResult);

            //Func decalarion ( with Lambda function)
            Func<int, int, int> intSumFunc = (a, b) => a + b;

            int intSumResult = intSumFunc(value1, value2);
            Console.WriteLine(intSumResult);
        }
    }
}
