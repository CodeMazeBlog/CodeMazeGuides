using System;
using System.Collections.Generic;

namespace ActionAndFunc
{
    public class Program
    {
        private const string Quote = "I am the one who knocks.";
        static void Main(string[] args)
        {
            Action<string> sayHello = new Action<string>(SayHello);
            sayHello(string.Empty);
            Action<string, string> sayMyName = new Action<string, string>(SayMyName);
            sayMyName(string.Empty, "Heisenberg");
            Func<int, bool> isEven = new(IsEven);
            string message = isEven(2) ? "It is even." : "It is odd";
            Func<string> getQuote = new(GetQuote);
            string quote = getQuote();
            Console.WriteLine(message);
            Console.WriteLine(quote);
        }
        static void SayHello(string message)
        {
            Console.WriteLine($"Hello {(string.IsNullOrWhiteSpace(message) ? "Code Maze" : message)}");
        }
        static void SayMyName(string name, string lastName)
        {
            Console.WriteLine($"You are {name + " " + lastName}.");
        }
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public static string GetQuote()
        {
            return Quote;
        }
    }
}
