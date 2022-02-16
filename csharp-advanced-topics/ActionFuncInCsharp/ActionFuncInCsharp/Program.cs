using System;

namespace ActionFuncInCsharp
{
    public delegate void logError(string message);

    class Program
    {
        static void Main(string[] args)
        {
            var log = new logError(ErrorMessage);
            log("Null value not accepted");
             
            Action<string> logError = ErrorMessage;
            logError("Null value is not accepted");

            Func<string, string> greetings = GreetUser;
            Console.WriteLine(greetings("John"));

            Action<string> logError2 = (message) => Console.WriteLine(message);
            logError2("Null value is not accepted");

            Func<string, string> greetings2 = (user) => $"Welcome back {user}. We are glad to see you";
            Console.WriteLine(greetings2("John"));
        }

        public static void ErrorMessage(string message)
        {
            Console.WriteLine($"Application down due to the following error: {message}");
        }

        public static string GreetUser(string user)
        {
            return $"Welcome back {user}. We are glad to see you";
        }
    }
}
