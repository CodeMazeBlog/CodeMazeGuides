using System;

namespace ActionFuncDelegatesCsharp
{
    public class UnderstandingDelegates
    {
        public string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
        public void PrintSumOfNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
        public bool CheckLengthOfString(string exampleString)
        {
            return exampleString.Length > 10;
        }
    }
}
