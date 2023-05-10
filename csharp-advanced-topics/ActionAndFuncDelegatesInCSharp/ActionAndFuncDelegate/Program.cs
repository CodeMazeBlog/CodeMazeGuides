namespace ActionAndFuncDelegate
{
	public static class Program
	{
		static void Main(string[] args)
		{
			ActionDelegateSample();

			Console.WriteLine($"\n");

			FuncDelegateSample();
		}

		public static void ActionDelegateSample()
		{
			Console.WriteLine("Action Delegate Result");

			Action<int, int> ActionCalculator = (a, b) =>
			{
				Console.WriteLine($"Addition result: {a + b}");
				Console.WriteLine($"Subtraction result: {a - b}");
				Console.WriteLine($"Multiplication result: {a * b}");
				Console.WriteLine($"Division result: {a / b}");
			};

			ActionCalculator(4, 2);
		}
		public static void FuncDelegateSample()
		{
			Console.WriteLine("Func Delegate Result");

			var FuncCalculator = new Calculator();

			Func<int, int, int> add = FuncCalculator.Add;
			Func<int, int, int> subtract = FuncCalculator.Subtract;
			Func<int, int, int> multiply = FuncCalculator.Multiply;
			Func<int, int, int> divide = FuncCalculator.Divide;

			Console.WriteLine($"Addition result: {add(4, 2)}");
			Console.WriteLine($"Subtraction result: {subtract(4, 2)}");
			Console.WriteLine($"Multiplication result: {multiply(4, 2)}");
			Console.WriteLine($"Division result: {divide(4, 2)}");
		}
	}
}
