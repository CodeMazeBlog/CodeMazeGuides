// C# program to illustrate Func delegate

namespace ActionAndFuncDelegate
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a = 50, b = 5;

            Func<int, int, int> AddFuncDelegate = new Func<int, int, int>(BasicMaths.Add);
            Func<int, int, int> SubFuncDelegate = new Func<int, int, int>(BasicMaths.Sub);

            int AddFuncDelegateResult = AddFuncDelegate(a, b);
            int SubFuncDelegateResult = SubFuncDelegate(a, b);

            Console.WriteLine($"{a} + {b} = {AddFuncDelegateResult}");
            Console.WriteLine($"{a} - {b} = {SubFuncDelegateResult}");

            Action<int> ActionDelegateEvenOrOdd = new Action<int>(BasicMaths.EvenOrOdd);
            Action<double, double> ActionDelegateMaximum = new Action<double, double>(BasicMaths.Maximum);

            ActionDelegateEvenOrOdd(21);
            ActionDelegateMaximum(10.30, 10.50);

            Console.ReadLine();
        }


    }
    public class BasicMaths
    {
        //Methods that takes parameters and returns a value:
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }

        //Methods that takes parameters but returns nothing:
        public static void EvenOrOdd(int number)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine("{0} is even number.", number);
            }
            else
            {
                Console.WriteLine("{0} is odd number.", number);
            }
        }

        public static void Maximum(double number1, double number2)
        {
            Console.WriteLine("Maximum of {0} and {1} is {2}.", number1, number2, Math.Max(number1, number2));
        }

    }

}
