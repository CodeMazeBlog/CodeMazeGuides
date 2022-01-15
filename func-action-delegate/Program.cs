using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionDelegate
{
    class Program
    {
        public static double AddNumber(int x, float y, double z)
        {
            return x + y + z;
        }

        public static int MultiplyNumber(int x, int y)
        {
            return x * y;
        }
        public static void AddNumber2(int x, float y, double z)
        {
            Console.WriteLine(x + y + z);   //Output -> 327.965
        }

        public static void MultiplyNumber(int x, int y, int z)
        {
            Console.WriteLine(x * y * z);  //Output -> 150
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Func<> Delegate");
            //First way of creating a Func<> Delegate
            Func<int, float, double, double> addition = new Func<int, float, double, double>(AddNumber);
            double result1 = addition.Invoke(100, 34.5f, 193.465);
            Console.WriteLine("Addition : " + result1);     //Output -> Addition : 327.965

            //Second way of creating a Func<> Delegate
            Func<int, int, int> product = MultiplyNumber;
            Console.WriteLine("Multiplication : " + product(67, 4));    //Output -> Multiplication : 268

            Console.WriteLine("Action<> Delegate");
            //First way of creating an Action<> Delegate
            Action<int, float, double> addition2 = new Action<int, float, double>(AddNumber2);
            addition2.Invoke(100, 34.5f, 193.465);

            //Second way of creating an Action<> Delegate
            Action<int, int, int> product2 = MultiplyNumber;
            product2(10, 3, 5);

            Console.ReadLine();
        }
    }
}
