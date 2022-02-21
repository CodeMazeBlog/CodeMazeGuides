using System;

namespace ActionInCSharp
{
    class Program
    {
        private static int resultNumber = 0;
        private static string resultMessage = "";
        static void Main(string[] args)
        {
            //Single input argument passed
            Action<string> MessageView = ShowMessage;
            MessageView("Code Maze in Action");
            Console.WriteLine($"Action with single = {resultMessage}");

            //Without lambda MultiplicationMethod(10, 20);
            Action<int, int> MultiplicationMethod = MultiplyNumbers; 
            MultiplicationMethod(10, 20);
            Console.WriteLine($"Action without lambda value = {resultNumber}");

            //With lambda MultiplicationMethodLambda(10, 20);
            Action<int, int> MultiplicationMethodLambda = (a, b) => MultiplyNumbers(a, b); 
            MultiplicationMethod(10, 20);
            Console.WriteLine($"Action with lambda value = {resultNumber}");
        }

        private static void MultiplyNumbers(int paramX, int paramY) { resultNumber = paramX * paramY; }
        private static void ShowMessage(string param) { resultMessage = param; }
    }
}
