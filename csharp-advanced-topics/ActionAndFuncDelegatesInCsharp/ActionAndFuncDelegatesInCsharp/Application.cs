using System;
using System.Collections.Generic;
using System.Text;

namespace ActionAndFuncDelegatesInCsharp
{
	public class Application
	{
		private readonly Calculator _calculator;
		//public Application()
		//{
		//	_calculator = new Calculator();
		//}
		private int _num1;
		private int _num2;
		public Application(int num1, int num2)
		{
			_calculator = new Calculator();
			_num1 = num1;
			_num2 = num2;
		}

		public int Result { get; private set; }

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

		public void ActionCalculatorUsingMethod()
		{
			Action<int, int> add = _calculator.AddUsingAction;
			add(_num1, _num2);
			Result = _calculator.Result;
		}
		public void ActionCalculatorUsingAnonymousMethod()
		{
			Action<int, int> add = (num1, num2) =>
			{
				Result = num1 + num2;
			};
			add(_num1, _num2);
		}

		public void FuncCalculatorUsingMethod()
		{
			Func<int, int, int> add = _calculator.AddUsingFunc;
			Result = add(_num1, _num2);
		}
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
