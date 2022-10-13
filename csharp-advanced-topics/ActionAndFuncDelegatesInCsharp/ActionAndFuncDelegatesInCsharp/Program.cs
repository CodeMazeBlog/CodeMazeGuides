using System;

namespace ActionAndFuncDelegatesInCsharp
{

    class Program
    {
        public delegate void SendMailDelegate(string email, string mailbody);

        static void Main(string[] args)
        {

            // create a delegate instance and assign the handler to it
            var handler = new SendMailDelegate(SendMailHandler);
            handler("abc@example.com", "This is sample message");

            ActionDelegateExamples();

            FuncDelegateExamples();
        }

        private static void ActionDelegateExamples()
        {
            // Example 1: Using Anonymous methods
            Action<string> hello = delegate (string name)
            {
                Console.WriteLine($"Hello {name}");
            };
            hello("David");


            // Example 2: Using Lambda expressions (Expression lambdas):
            Action<int, int> sum = (int x, int y) => Console.WriteLine(x + y);
            sum(3, 4);

            // Example 3: Using Lambda expressions (Statement lambdas):
            Action<int, int> add = (int x, int y) =>
            {
                Console.WriteLine(x + y);
            };
            add(10, 20);
        }

        private static void FuncDelegateExamples()
        {
            // Example 1: Using Anonymous methods:
            Func<string, string> hello = delegate (string name)
            {
                return $"Hello {name}";
            };
            Console.WriteLine(hello("David"));

            // Example 2: Using Lambda expressions (Expression lambdas):
            Func<int, int, int> sum = (int x, int y) => x + y;
            Console.WriteLine(sum(5, 10));

            // Example 3: Using Lambda expressions (Statement lambdas):
            Func<int, int, int> add = (int x, int y) =>
            {
                return x + y;
            };
            Console.WriteLine(add(10, 20));
        }


        // create an handler
        public static void SendMailHandler(string email, string mailbody)
        {
            Console.WriteLine("Message has been sent successfully!");
        }
    }
}