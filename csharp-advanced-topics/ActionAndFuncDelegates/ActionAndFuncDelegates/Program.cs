using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        public delegate void ourFirstDelegate(int x);

        static void Main(string[] args)
        {
            var firstVariable = 1;

            var secondVariable = DoubleTheVariable(firstVariable);

            PrintVariable(secondVariable);

            var firstDelegate = new ourFirstDelegate(PrintVariable);

            firstDelegate(200);

            PassADelegeteToAFunction(firstDelegate);

            Func<string, string> HelloFuncDelegate = HelloFunction;

            Action<string> GoodbyeActionDelegate = GoodbyeFunction;

        }

        public static int DoubleTheVariable(int parameter)
        {
            return parameter * 2;
        }

        public static void PrintVariable(int parameter)
        {
            Console.WriteLine(parameter);
        }

        public static void PassADelegeteToAFunction(ourFirstDelegate myDelegate)
        {
            myDelegate(100);
        }

        public static string HelloFunction(string name)
        {
            return "Hello " + name;
        }

        public static void GoodbyeFunction(string name)
        {
            Console.WriteLine("Goodbye " + name);
        }
    }
}
