using System;
using System.Linq;
using System.Collections.Generic;

namespace ActionAndFuncDelegatesInCsharp
{
    public class Program
    {
        delegate void ErrorLogger(Exception ex);
        public static List<string> names = new List<string> { "mike", "debby", "sarah", "fergus", "hodor" };
        public static Func<string, bool> filter = n => n.Length == 5;
        public static Action<string> print = n => Console.WriteLine(n);

        static void Main(string[] args)
        {
            FireDelegateException();
        }

        public static void FireDelegateException()
        {
            ErrorLogger ErrorHandlerOne = new ErrorLogger(LogError);
            ErrorHandlerOne.Invoke(new Exception("Houston, we have a problem"));
        }

        public static void FireActionException()
        {
            Action<Exception> ErrorHandlerTwo = LogError;
            ErrorHandlerTwo.Invoke(new Exception("Houston, we have a problem"));
        }

        public static void PrintAllNames()
        {
            names.ForEach(print);
        }

        public static void PrintFiveLetterNames()
        {
            var fiveLetterNames = names.Where(filter).ToList();
            fiveLetterNames.ForEach(print);
        }

        public static void LogError(Exception ex)
        {
            // Error logging logic.
            Console.WriteLine($"New {ex.GetType()}");
            Console.WriteLine("=================================");
            Console.WriteLine($"Time           | {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            Console.WriteLine($"Message        | {ex.Message}");
            Console.WriteLine($"Stack Trace    | {ex.StackTrace}");
            Console.WriteLine("");
        }

    }
}
