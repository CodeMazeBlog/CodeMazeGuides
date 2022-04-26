using System;

namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionFuncDelegate actionFuncDelegate = new ActionFuncDelegate();

            Action<string, string> actionGreeting = actionFuncDelegate.PrintText;
            actionGreeting("Hello", "World");

            Action currentDateTime = actionFuncDelegate.PrintDateTime;
            currentDateTime();

            actionGreeting = actionFuncDelegate.PrintText;
            actionGreeting += actionFuncDelegate.PrintTextGreeting;
            actionGreeting("Hello", "World");

            actionGreeting = delegate (string a, string b)
            {
                Console.WriteLine($"{a} {b}");
            };

            actionGreeting += (a, b) => Console.WriteLine($"{a} {b}, welcome to the show!");
            actionGreeting("Hello", "World");

            Func<string> funcGreeting = actionFuncDelegate.GetGreeting;
            var stringResult = funcGreeting();
            Console.WriteLine(stringResult);

            Func<int, int, int> product = actionFuncDelegate.MultiplyIntegers;
            var intResult = product(4, 5);
            Console.WriteLine(intResult);
        }
    }

    public class ActionFuncDelegate
    {
        public string Result { get; set; }

        public string GetGreeting()
        {
            return "Hello World";
        }

        public void PrintDateTime()
        {
            Result = DateTime.Now.ToString();
            Console.WriteLine(Result);
        }

        public void PrintText(string a, string b)
        {
            Result = $"{a} {b}";
            Console.WriteLine(Result);
        }

        public void PrintTextGreeting(string a, string b)
        {
            Result = $"{a} {b}, welcome to the show!";
            Console.WriteLine(Result);
        }

        public int MultiplyIntegers(int a, int b)
        {
            return a * b;
        }
    }
}

