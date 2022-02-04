using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> sumDelegate = Sum;
            Console.WriteLine(sumDelegate(10, 20));
            Console.ReadLine();
        }
        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
