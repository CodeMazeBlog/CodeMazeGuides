using System;

namespace delegate_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the delegate
            Func<string, string> helloWorld = print;

            // Call the delegate
            Console.WriteLine(helloWorld("CodeMaze"));
        }

        // Declare method for delegate
        public static string print(string message)
        {
            return "Welcome to " + message;
        }
    }
}
