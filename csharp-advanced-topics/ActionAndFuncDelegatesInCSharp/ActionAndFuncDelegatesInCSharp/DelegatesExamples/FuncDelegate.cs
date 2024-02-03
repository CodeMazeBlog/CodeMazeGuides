using System;
namespace ActionAndFuncDelegatesInCSharp.DelegatesExamples
{
	public class FuncDelegate
	{
		public void Execute()
		{
            //Func Examples
            Func<int, int, string> FuncMathOperations = Multiply;
            Console.WriteLine(FuncMathOperations(5, 5));
            FuncMathOperations = Add;
            Console.WriteLine(FuncMathOperations(5, 5));
            FuncMathOperations = Divide;
            Console.WriteLine(FuncMathOperations(5, 5));
            FuncMathOperations = Subtract;
            Console.WriteLine(FuncMathOperations(5, 5));

            //Func Annonymous Implementation
            Func<int, int, string> FuncMathAnonOperations = delegate (int a, int b)
            { return $"Multiplication Result(Anon Delegate) : {a * b}"; };
            Console.WriteLine(FuncMathAnonOperations(5, 5));

            //Func Lamda Implementation
            Func<int, int, string> FuncMathLamdaOperations = (int a, int b) =>
            { return $"Multiplication Result(Lamda Delegate) : {a * b}"; };
            Console.WriteLine(FuncMathLamdaOperations(5, 5));
        }

        public string Multiply(int a, int b)
        {
            return $"Multiplication Result : {a * b}";
        }

        public string Add(int a, int b)
        {
            return $"Addition Result : {a + b}";
        }

        public string Divide(int a, int b)
        {
            return $"Division Result : {a / b}";
        }

        public string Subtract(int a, int b)
        {
            return $"Subtraction Result : {a - b}";
        }
    }
}

