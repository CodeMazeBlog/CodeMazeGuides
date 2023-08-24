using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DifferentTypesOfCommentsInCSharp
{
    // IMPORTANT:
    //   There are too many comments in this code. These comments
    //     are here to show you examples of commenting code.


    //   This file shows a few examples of single-line comments
    public static class SingleLineComments
    {
        // The function calculates the factorial of a given number.
        //
        // The algorithm to calculate factorial is multiplying
        //      every whole number from 1 to the given number.
        //
        //  A factorial of a negative number is not defined.
        //
        //  A Factorial of 0 is 1
        public static long Factorial(int number)
        {
            if (number < 0) // Check if the number is less than 0 and throw an exception if it is.
                throw new ArgumentException("Arguments must be greater or equal to zero.");

            if (number <= 1) 
                return 1; // A factorial of 0 and 1 is 1.

            // Calculate factorial in a loop, multiplying every number with the current result.
            long result = 1;  // Starting with 1
            for (int n = 2; n <= number; n++)
                result *= n; // Multiply the current number with running result

            // Returning result
            return result;
        }
    }
}
