using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionActionDelegatesInCsharp
{
    public class FunctionAction
    {

        static void Main(string[] args)
        {
            Func<int, int, int> add = (int first, int second) => first + second;
            var resultAdd = add(1, 2);

            Func<int, int, int> sub = Subtract;
            var resultSub = sub(20, 2);

            var random = new Random();
            Func<int> mult = () => random.Next(0, 20) * 2;


            Action<int> print = Console.WriteLine;
            PrintEven(2, print);
        }

        public static int Subtract(int first, int second)
        {
            return first - second;
        }

        public static void PrintEven(int i, Action<int> printEven)
        {
            if (i % 2 == 0) printEven(i);
        }
    }
}
