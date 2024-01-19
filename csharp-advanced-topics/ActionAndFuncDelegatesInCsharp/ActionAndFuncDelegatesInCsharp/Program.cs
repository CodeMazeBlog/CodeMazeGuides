namespace ActionAndFuncDelegatesInCsharp
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Here is an example with Action Delegates");

			Action<int, int> Addition_Action = AddActionNumbers;
			Addition_Action(4, 8);

			Console.WriteLine("\n");

			Console.WriteLine("Here is an example with Func Delegates");

			Func<int, int, int> Addition_Func = AddFuncNumbers;
			int sum = Addition_Func(4, 8);
			Console.WriteLine("The sum of the addition is: " + sum);
		}

		public static void AddActionNumbers(int a, int b)
		{
			Console.WriteLine($"The sum of the addition is: {a + b}");
		}

		public static int AddFuncNumbers(int i, int j)
		{
			return i + j;
		}
	}
}