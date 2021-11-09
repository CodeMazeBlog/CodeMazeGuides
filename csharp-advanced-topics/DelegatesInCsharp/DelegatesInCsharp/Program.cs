using System;

namespace DelegatesInCsharp
{
    public delegate string DelegateFullName(string firstName, string lastName);
    public delegate void DelegatePrintSumOfNumbers(int firstNumber, int secondNumber);
    public delegate bool DelegateCheckLengthOfString(string exampleString);
    class Program
    {
        static void Main(string[] args)
        {
            var firstNumber = 5;
            var secondNumber = 10;
            var exampleString = "AmazingCodeMaze";
            var firstName = "Code";
            var lastName = "Maze";

            UnderstandingDelegates understandingDelegates = new UnderstandingDelegates();

            #region Implementing Delegates Without Generics

            Console.WriteLine("-------------- Prints Using Normal Delegate Invocation ---------------------");

            DelegateFullName delegateFullName = understandingDelegates.GetFullName;
            var fullName = delegateFullName.Invoke(firstName, lastName);
            Console.WriteLine(fullName);

            DelegatePrintSumOfNumbers delegateSum = understandingDelegates.PrintSumOfNumbers;
            delegateSum.Invoke(firstNumber, secondNumber);

            DelegateCheckLengthOfString delegateCheckLengthOfString = understandingDelegates.CheckLengthOfString;
            Console.WriteLine(delegateCheckLengthOfString.Invoke(exampleString));

            #endregion


            #region Implementing Delegates With Generics
            //Here we don't need to define delegates mentioned in line numbers 5,6 and 7
            Console.WriteLine("\n-------------- Prints Using Generic Delegate Invocation --------------------\n");

            Console.WriteLine("-------------- Implementing Func Delegate ----------------------------------");
            Func<string, string, string> funcDelegateFullName = understandingDelegates.GetFullName;
            var fullNameWithFuncDelegate = funcDelegateFullName.Invoke(firstName, lastName);
            Console.WriteLine(fullNameWithFuncDelegate);

            Console.WriteLine("-------------- Implementing Action Delegate --------------------------------");
            Action<int, int> sumWithActionDelegate = understandingDelegates.PrintSumOfNumbers;
            sumWithActionDelegate.Invoke(firstNumber, secondNumber);

            Console.WriteLine("-------------- Implementing Predicate Delegate -----------------------------");
            Predicate<string> stringLengthWithPredicateDelegate = understandingDelegates.CheckLengthOfString;
            var resultOfPredicateDelegate = stringLengthWithPredicateDelegate.Invoke(exampleString);
            Console.WriteLine(resultOfPredicateDelegate);

            Console.WriteLine("-------------- Implementing Predicate using Func Delegate ------------------");
            Func<string, bool> stringLengthWithFuncDelegate = understandingDelegates.CheckLengthOfString;
            var resultOfPredicateWithFuncDelegate = stringLengthWithFuncDelegate.Invoke(exampleString);
            Console.WriteLine(resultOfPredicateWithFuncDelegate);

            #endregion

            Console.ReadLine();
        }
    }
}
