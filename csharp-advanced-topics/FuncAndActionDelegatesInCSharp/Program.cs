using System;

namespace FuncAndActionDelegatesInCSharp
{
    internal class Program
    {
        public delegate float CalculateFormula(float x, float y);

        public static float CalculateFirstFormula(float x, float y)
        {
            return (x * y) / (x + y);
        }

        public static void CalculateSecondFormula(float x)
        {
            float PI = 3.14f;
            Console.WriteLine($"Second Calculation is {x * x * PI}");
        }

        public static bool PrintTrue()
        {
            return true;
        }

        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to our site!");
        }

        static void Main(string[] args)
        {
            CalculateFormula calc = CalculateFirstFormula;
            Console.WriteLine(calc(1f, 1f));

            Func<float, float, float> calculationHandler = CalculateFirstFormula;
            Console.WriteLine(calculationHandler(1f, 1f));

            Func<bool> printTrueHandler = PrintTrue;
            Console.WriteLine($"Printing true: {printTrueHandler()}");

            Action<float> calcHandler = CalculateSecondFormula;
            calcHandler(2.0f);

            Action messageHandler = PrintWelcomeMessage;
            messageHandler();
        }
    }
}