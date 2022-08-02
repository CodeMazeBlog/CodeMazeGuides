using System;

namespace FuncActionDelegates
{
	//Declaring a delegate
	delegate void PrintMessage(string text);
	
	class Program
	{
		//----------------------------- Secondary functions and variables to run the examples -----------------------------------

		public static int result3;
		public static int result4;
		public static int result5;

		public static void WriteText(string text) { Console.WriteLine(text); }
		public static int AddNumbers(int param1, int param2) { return param1 + param2; }
		public static void AddTwoNumbers3(int param1, int param2) { result3 = param1 + param2; }

		//-----------------------------------------------------------------------------------------------------------------------

		static void Main(string[] args)
		{
	    
		//------------------------------------------ Using delegates examples -----------------------------------------------

			//Example1 to instantiate the delegate
			var delegate1 = new PrintMessage(WriteText);

			//Example2 now let's simplify how to instantiate the delegate
			var delegate2 = WriteText;

			//Example3 we use an Anonymous method to instantiate the delegate
			var delegate3 = delegate (string text) { Console.WriteLine($"Text: {text}"); };

			//Example4 it is possible to use a Lambda Expression to instantiate the delegate
			PrintMessage delegate4 = text => { Console.WriteLine($"Text: {text}"); };

			//Invoking a delegate with keyword "Invoke"
			delegate1.Invoke("Go ahead, make my day.");
			
			//Invoking a delegate with ()
			delegate1("Go ahead, make my day.");

		//------------------------------------------ Func Delegate examples -------------------------------------------------

			//Example1 using Func delegate
			Func<int, int, int> AddTwoNumbers = AddNumbers; 
			int result = AddTwoNumbers(10, 20); 
			Console.WriteLine($"AddTwoNumbers = {result}");

			//Example2 Func delegate with an Anonymous Method
			Func<int, int, int> AddTwoNumbers1 = delegate (int param1, int param2) { return param1 + param2; }; 
			int result1 = AddTwoNumbers1(10, 20); 
			Console.WriteLine($"AddTwoNumbers1 = {result1}");

			//Example3 Func delegate with Lambda Expression
			Func<int, int, int> AddTwoNumbers2 = (param1, param2) => param1 + param2; 
			int result2 = AddTwoNumbers2(10, 20); 
			Console.WriteLine($"AddTwoNumbers2 = {result2}");

		//------------------------------------------ Action Delegate examples -----------------------------------------------

			//Example1 Action delegate is the method "AddTwoNumbers3" that takes 2 parameters but returns nothing
			Action<int, int> Addition = AddTwoNumbers3; 
			Addition(10, 20); 
			Console.WriteLine($"Addition = {result3}");

			//Example2 Action delegate with an Anonymous method
			Action<int, int> Addition1 = delegate (int param1, int param2) { result4 = param1 + param2; };
			Addition1(10, 20);
			Console.WriteLine($"Addition1 = {result4}");

			//Example3 Action delegate can use a Lambda expression
			Action<int, int> Addition2 = (param1, param2) => result5 = param1 + param2;
			Addition2(10, 20); 
			Console.WriteLine($"Addition2 = {result5}");
		}
	}
}
