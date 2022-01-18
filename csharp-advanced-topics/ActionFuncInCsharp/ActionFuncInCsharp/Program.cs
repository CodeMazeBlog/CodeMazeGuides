using System;

namespace ActionFuncInCsharp
{
    public delegate void LogError(string message);
    class Program
    {
        static void Main(string[] args)
        {
            //instantiating delegate
            var log = new LogError(ErrorMessage);

            //invoking delegate
            log("Null value not accepted");

            //instantiating Action with method
            Action<string> LogError = ErrorMessage;

            //instantiating Action with lambda expression
            //Action<string> LogError = (message) => Console.WriteLine(message);

            //invoking Action
            LogError("Null value is not accepted");

            //instantiating Func with method
            Func<string, string> greetings = GreetUser;

            //instantiating Func with lambda expression
            //Func<string, string> greetings = (user) => $"Welcome back {user}. We are glad to see you";

            //invoking Func
            Console.WriteLine(greetings("John"));
            

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
