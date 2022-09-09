using System;

namespace FuncActionDelegates
{
	class Program
	{
		static void Main(string[] args)
		{
			var delegate1 = new PrintMessageConsole(SampleFunctions.WriteTextConsole);
			var delegate2 = SampleFunctions.WriteText;
			var delegate3 = delegate (string text) { Console.WriteLine($"Text: {text}"); };
			PrintMessageConsole delegate4 = text => { Console.WriteLine($"Text: {text}"); };

			delegate1.Invoke("Go ahead, make my day.");
			delegate1("Go ahead, make my day.");

			Func<int, int, int> AddTwoNumbers1 = SampleFunctions.AddNumbers; 
			int result1 = AddTwoNumbers1(10, 20); 
			Console.WriteLine($"AddTwoNumbers1 = {result1}");

			Func<int, int, int> AddTwoNumbers2 = delegate (int param1, int param2) { return param1 + param2; }; 
			int result2 = AddTwoNumbers2(10, 20); 
			Console.WriteLine($"AddTwoNumbers2 = {result2}");

			Func<int, int, int> AddTwoNumbers3 = (param1, param2) => param1 + param2; 
			int result3 = AddTwoNumbers3(10, 20); 
			Console.WriteLine($"AddTwoNumbers3 = {result3}");

			Action<int, int> Addition1 = SampleFunctions.AddTwoNumbers; 
			Addition1(10, 20); 

			Action<int, int> Addition2 = delegate (int param1, int param2) { SampleFunctions.result = param1 + param2; };
			Addition2(10, 20);
			Console.WriteLine($"Addition1 = {SampleFunctions.result}");

			Action<int, int> Addition3 = (param1, param2) => SampleFunctions.result = param1 + param2;
			Addition3(10, 20);
			Console.WriteLine($"Addition2 = {SampleFunctions.result}");
		}
	}
}
