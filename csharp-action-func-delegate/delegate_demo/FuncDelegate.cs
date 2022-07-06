using System;
using System.Collections.Generic;
using System.Text;

namespace delegate_demo
{
    public class FuncDelegate
    {
        public static void FuncExample(string[] args)
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
