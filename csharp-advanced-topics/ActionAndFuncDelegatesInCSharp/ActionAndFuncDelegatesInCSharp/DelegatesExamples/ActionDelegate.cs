using System;
namespace ActionAndFuncDelegatesInCSharp.DelegatesExamples
{
	public class ActionDelegate
	{
        public void Execute()
        {
            //Action Examples
            Action<int, int> ActionMathOperations = PrintMultiplyResult;
            ActionMathOperations(5, 5);

            //Action Annonymous Implementation
            Action<int, int> ActionMathAnonOperations = delegate (int a, int b)
            { Console.WriteLine($"Print my Multiplication Result(Anon Delegate) : {a * b}"); };
            ActionMathAnonOperations(5, 5);

            //Action Lamda Implementation
            Action<int, int> ActionMathLamdaOperations = (int a, int b) =>
            { Console.WriteLine($"Print my Multiplication Result(Lamda Delegate) : {a * b}"); };
            ActionMathLamdaOperations(5, 5);
        }

        public void PrintMultiplyResult(int a, int b)
        {
            Console.WriteLine($"Print my Multiplication Result : {a * b}");
        }
    }
}

