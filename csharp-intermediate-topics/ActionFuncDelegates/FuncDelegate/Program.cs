using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegate
{
    public class Program
    {
        public static int square(int n)
        {
            return n * n;
        }
        public static void Main(string[] args)
        {
            // create an Func delegate and assign it a method
            Func<int, int> funcSquare = square;

            // calling the Action
            Console.WriteLine(funcSquare(2));

            // alternate-1: using the anonymous method
            Func<int, int> funcSquare2 = delegate (int n) { return n * n; };

            Console.WriteLine(funcSquare2(4));

            // alternate-2: using the lambda expression
            Func<int, int> funcSquare3 = n => n * n;

            Console.WriteLine(funcSquare3(8));
        }
    }
}
