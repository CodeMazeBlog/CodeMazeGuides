using System;

namespace ActionAndFuncDelegatesInCsharp
{
	class Program
	{
		delegate void Print(int val);
		delegate int Sum(int x, int y);
	
		static void ConsolePrint(int i)
		{
			Console.WriteLine(i);
		}
		
		static int Add(int x, int y)
		{
			return x + y;
		}
	
		static void Main(string[] args)
		{
			// Demonstrate Action delegates behavior
			Print printRegularDelegate = ConsolePrint;
			Console.Write("Using a self-created delegate to print...");
			printRegularDelegate(10);
			
			Action<int> printActionDelegate = ConsolePrint;
			Console.Write("Using an action delegate to print...");
			printActionDelegate(10);
			
			Action<int> printActionDelegateAnonymous = delegate(int i) { Console.WriteLine(i); };
			Console.Write("Using an action delegate with an anonymous function to print...");
			printActionDelegateAnonymous(10);
			
			Action<int> printActionDelegateLambda = i => Console.WriteLine(i);
			Console.Write("Using an action delegate with a lambda expression to print...");
			printActionDelegateLambda(10);
			
			// Demonstrate Func delegates behavior
			int result = default;
			
			Sum addRegularDelegate = Add;
			result = addRegularDelegate(6, 4);
			Console.Write("Using a self-created delegate to add two values together...");
			Console.WriteLine(result);
			
			Func<int, int, int> addFuncDelegate = Add;
			result = addFuncDelegate(6, 4);
			Console.Write("Using a func delegate to add two values together...");
			Console.WriteLine(result);
			
			Func<int, int, int> addFuncDelegateAnonymous = delegate(int x, int y) { return x + y; };
			result = addFuncDelegateAnonymous(6, 4);
			Console.Write("Using a func delegate with an anonymous function to add two values together...");
			Console.WriteLine(result);
			
			Func<int, int, int> addFuncDelegateLambda = (x, y) => x + y;
			result = addFuncDelegateLambda(6, 4);
			Console.Write("Using a func delegate with a lambda expression to add two values together...");
			Console.WriteLine(result);
		}
	}
}