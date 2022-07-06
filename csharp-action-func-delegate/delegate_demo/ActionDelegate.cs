using System;
using System.Collections.Generic;
using System.Text;

namespace delegate_demo
{
    public class ActionDelegate
    {
        public static void ActionExample(string[] args)
        {
            // Instantiate the delegate
            Action<string> helloWorld = print;

            // Call the delegate
            helloWorld("Welcome to CodeMaze");
        }

        // Declare method for delegate
        public static void print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
