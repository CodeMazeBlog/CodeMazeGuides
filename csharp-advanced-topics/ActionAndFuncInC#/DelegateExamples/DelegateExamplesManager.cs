using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    public static class DelegateExamplesManager
    {
        public static void ActionExample()
        {
            // Declare an Action delegate that accepts a string parameter
            Action<string> displayMessage = (message) => Console.WriteLine(message);

            // Call the delegate with a string parameter
            displayMessage("Hello, World!");
        }

        public static int FuncExample()
        {
            // Declare a Func delegate that accepts two int parameters and returns an int
            Func<int, int, int> addNumbers = (a, b) => a + b;

            // Call the delegate with two int parameters
            int result = addNumbers(5, 10);

            // Return the result
            return result;
        }
    }
}
