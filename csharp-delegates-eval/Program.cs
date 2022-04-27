using System;

namespace DelegateDemo
{
   public class Program
    {
        static void Main(string[] args)
        {
            Program parse = new Program();
            var n1 = 3; //int variables

            PrintNumber(n1);


            var firstDelegate = new SampleDelegate(PrintNumber);
            // example for Delegate chain
            firstDelegate += AddNumber;
            firstDelegate += MultiplyNumber;


            Action action = PrintHelloWorld;
            action.Invoke();

            Action<int> action2 = MultiplyNumber;

            Func<decimal, decimal, int> func1 = CalculateNumbers;
            var number = func1.Invoke(Convert.ToDecimal(2.1), Convert.ToDecimal(2.2));
            Console.WriteLine($"The result of the func is: {number}");

            var secondDelegate = new SampleDelegate(MultiplyNumber);

            DelegateHandler(firstDelegate);
        }

        public static int CalculateNumbers(decimal x, decimal y)
        {

            return Convert.ToInt32(x * y);
        }
        public static void PrintHelloWorld()
        {

            Console.WriteLine("Hello World!");
        }
        public static void PrintNumber(int num)
        {

            Console.WriteLine($"The number is:{num}");
        }

        public static void MultiplyNumber(int num)
        {
            num *= 2;
            Console.WriteLine($"The multiplied number is:{num}");
        }

        public static void AddNumber(int num)
        {
            num += 100;
            Console.WriteLine($"The added number is: {num}");
        }
        public static void DelegateHandler(SampleDelegate deleg)
        {

            deleg(23);
        }
    }

  
}
