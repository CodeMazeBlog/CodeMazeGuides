namespace ActionFuncDelegates
{
	class Program
	{	
		static void Main(string[] args)
		{
			Action<string> greetDelegate = (name) =>
			{
				Console.WriteLine($"Hello, {name}!");
			};

			Func<int, int, int> sumDelegate = (a, b) =>
			{
				return a + b;
			};

			greetDelegate("John"); // Output: Hello, John!
			greetDelegate("Jane"); // Output: Hello, Jane!

			int result = sumDelegate(5, 3);
			Console.WriteLine($"Sum: {result}"); // Output: Sum: 8
		}
	}
}
