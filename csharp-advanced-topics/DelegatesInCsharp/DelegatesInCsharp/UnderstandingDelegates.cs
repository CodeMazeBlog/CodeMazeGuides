using System;

namespace DelegatesInCsharp
{
    public class UnderstandingDelegates
    {
        /// <summary>
        /// Returns full name concatenating first name and last name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        /// <summary>
        /// Prints the sum of two numbers
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        public void PrintSumOfNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }

        /// <summary>
        /// Returns bool either true or false if the length of the supplied string is greater than 10
        /// </summary>
        /// <param name="exampleString"></param>
        /// <returns></returns>
        public bool CheckLengthOfString(string exampleString)
        {
            return exampleString.Length > 10;
        }
    }
}
