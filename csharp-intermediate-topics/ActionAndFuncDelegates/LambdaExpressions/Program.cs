using System;
using System.Collections.Generic;

namespace LambdaExpressions
{
    internal class Program
    {
        private static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        private static void SaySomething(string messageToSay)
        {
            Console.WriteLine(messageToSay);
        }

        static void Main(string[] args)
        {
            Func<int, int, int> sumFunc = Sum;
            // Writes 4 to the console
            Console.WriteLine(sumFunc.Invoke(2, 2));
            Action<string> saySomethingAction = SaySomething;
            // Writes "Hi!" to the console
            saySomethingAction.Invoke("Hi!");

            Func<int, int, int> sumFunc2 = (num1, num2) => num1 + num2;
            // Writes 4 to the console
            Console.WriteLine(sumFunc.Invoke(2, 2));
            Action<string> saySomethingAction2 = (messageToSay) => { Console.WriteLine(messageToSay); };
            // Writes "Hi!" to the console
            saySomethingAction.Invoke("Hi!");

            // Writes 1, 2, 3 to the console
            List<int> nums = new() { 1, 2, 3 };
            Action<int> processNum = (num) => { Console.WriteLine(num); };
            nums.ForEach(processNum);
        }
    }
}
