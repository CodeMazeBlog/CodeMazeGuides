using System;
using System.Collections.Generic;
using System.Text;

namespace delegate_demo
{
    public class DelegateExample
    {
        // Declare delegate
        public delegate void HelloWorld(string message);

        public static void DelExample(string[] args)
        {
            // Instantiate the delegate
            HelloWorld helloWorld = print;

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
