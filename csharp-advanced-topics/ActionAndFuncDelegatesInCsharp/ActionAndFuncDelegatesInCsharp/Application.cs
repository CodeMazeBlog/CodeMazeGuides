using System;
using System.Collections.Generic;
using System.Text;

namespace ActionAndFuncDelegatesInCsharp
{
	public class Application
	{
		//variable definition.
		private readonly Calculator _calculator;
		private readonly int _num1;
		private readonly int _num2;
		public Application(int num1, int num2)
		{
			_calculator = new Calculator();
			_num1 = num1;
			_num2 = num2;
		}

		/// <summary>
		/// Result of calculation of _num1 and _num2.
		/// </summary>
		public int Result { get; private set; }

		/// <summary>
		/// method to switch through the various example methods.
		/// </summary>
		public void SwitchView()
		{
			Console.WriteLine("Please enter your preference.");
			Console.WriteLine("1 for Action delegate using method");
			Console.WriteLine("2 for Action delegate using anonymous method");
			Console.WriteLine("3 for Func delegate using method");
			Console.WriteLine("4 for Func delegate using anonymous method");

			var input = Console.ReadLine();

			var outputBy = "";
			switch (input)
			{
				case "1":
					ActionCalculatorUsingMethod();
					outputBy = "Action delegate using Method";
					break;
				case "2":
					ActionCalculatorUsingAnonymousMethod();
					outputBy = "Action delegate using Anonymous Method";
					break;
				case "3":
					FuncCalculatorUsingMethod();
					outputBy = "Func delegate using Method";
					break;
				case "4":
					FuncCalculatorUsingAnonymousMethod();
					outputBy = "Func delegate using Anonymous Method";
					break;
				default:
					Console.Clear();
					Console.WriteLine("Invalid input");
					SwitchView();
					break;
			}
			Console.WriteLine($"{_num1} + {_num2} = {Result}. {outputBy}");

			Console.WriteLine("--------------------------------------");
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();

			Console.WriteLine("--------------------------------------");
			SwitchView();
		}
		
		/// <summary>
		/// Example method one using Action delegate pointing to a method with same signature.
		/// Method pointed to is _calculator.AddUsingAction method in the Calculator class.
		/// </summary>
		public void ActionCalculatorUsingMethod()
		{
			Action<int, int> add = _calculator.AddUsingAction;
			add(_num1, _num2);
			Result = _calculator.Result;
		}
		/// <summary>
		/// Example method two using Action delegate with an anonymous method.
		/// </summary>
		public void ActionCalculatorUsingAnonymousMethod()
		{
			Action<int, int> add = (num1, num2) =>
			{
				Result = num1 + num2;
			};
			add(_num1, _num2);
		}
		/// <summary>
		/// Example method three using Func delegate pointing to a method with same signature.
		/// Method pointed to is _calculator.AddUsingFunc method in the Calculator class.
		/// </summary>
		public void FuncCalculatorUsingMethod()
		{
			Func<int, int, int> add = _calculator.AddUsingFunc;
			Result = add(_num1, _num2);
		}
		/// <summary>
		/// Example method four using Func delegate with an anonymous method which returns the result of
		/// the addition of num1 and num2.
		/// </summary>
		public void FuncCalculatorUsingAnonymousMethod()
		{
			Func<int, int, int> add = (num1, num2) =>
			{
				return num1 + num2;
			};
			Result = add(_num1, _num2);
		}
	}

}
