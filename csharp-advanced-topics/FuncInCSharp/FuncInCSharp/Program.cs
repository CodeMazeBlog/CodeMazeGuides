using System;

namespace FuncInCSharp
{
    class Program
    {
        private static string resultMessage;
        static void Main(string[] args)
        {
            //without lambda resultMessage = MutipleFuncMethod(5, 3);
            Func<int, int, string> MutipleFuncMethod = MultipleFuncNumbers; 
            resultMessage = MutipleFuncMethod(5, 3);
            Console.WriteLine($"Func without lambda = {resultMessage}");

            //with lambda resultMessage = MutipleFuncMethod(5, 3);
            Func<int, int, string> MutipleFuncLambdaMethod = (a, b) => MultipleFuncNumbers(a, b); 
            resultMessage = MutipleFuncLambdaMethod(5, 3);
            Console.WriteLine($"Func with lambda = {resultMessage}");
        }

        private static string MultipleFuncNumbers(int a, int b) 
        { 
            return "Mutiplied number : " + a * b; 
        }
    }
}
