using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DifferentTypesOfCommentsInCSharp
{
    /// <summary>
    ///   Class <c>DocumentationComments</c> shows different possibilities 
    ///     when using documentation comments in C# code
    /// </summary>
    public static class DocumentationComments
    {
        /// <summary>
        /// The function calculates the factorial of a given number.
        /// <br />
        /// 
        /// <example>
        /// For example:
        /// <code>
        ///   DocumentationComments.Factorial(6) == 720
        /// </code>
        /// </example>
        /// </summary>
        /// 
        /// <remarks>
        /// The algorithm to calculate factorial is multiplying
        ///    every whole number from 1 to the given number.
        /// <br />
        /// A factorial of a negative number is not defined.
        /// <br />
        /// A factorial of 0 is 1
        /// </remarks>
        /// 
        /// <param name="number">The number for which you want to calculate factorial.</param>
        /// 
        /// <returns>Calculated factorial</returns>
        /// 
        /// <exception cref="ArgumentException">Thrown when the argument is less than zero</exception>
        public static long Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Arguments must be greater or equal to zero.");

            if (number <= 1) 
                return 1;

            long result = 1;
            for (int n = 2; n <= number; n++)
                result *= n;

            return result;
        }

        /// <summary>
        ///   The method calculates the tax for a given price and the tax percentage. 
        ///   Price can be given with or without tax.
        /// </summary>
        /// <param name="price">Price with or without tax</param>
        /// <param name="percentageOfTax">Percentage of tax</param>
        /// <param name="priceIsWithTax"><c>True</c> if price contains tax, <c>false</c> otherwise</param>
        /// <returns>Value of tax</returns>
        public static double CalculateTax(double price, double percentageOfTax, bool priceIsWithTax = false)
        {
            double percentage = percentageOfTax / 100;
            return (priceIsWithTax)
                ? price * percentage / (1 + percentage)
                : price * percentage;
        }
    }
}
