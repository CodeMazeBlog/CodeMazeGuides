namespace ActionAndFuncDelegatesInCsharp
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Here is an example with Action delegates");

			Action<int, int> additionAction = AddActionNumbers;
			additionAction(4, 8);

			Console.WriteLine("\nHere is an example with Func delegates");

			Func<int, int, int> additionFunc = AddFuncNumbers;
			var sum = additionFunc(4, 8);
			Console.WriteLine("The addition's sum: " + sum);
		}

		public static void AddActionNumbers(int a, int b)
		{
			Console.WriteLine($"The addition's sum: {a + b}");
		}

		public static int AddFuncNumbers(int i, int j)
		{
			return i + j;
		}
	}
}