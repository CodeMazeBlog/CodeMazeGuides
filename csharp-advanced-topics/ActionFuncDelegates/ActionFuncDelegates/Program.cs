public class Program
{
	static void Main(string[] args)
	{
		// Example using Action delegate
		GreetUser("John", (greeting) =>
		{
			Console.WriteLine(greeting);
		});

		// Example using Func delegate
		int sum = AddNumbers(5, 3, (a, b) =>
		{
			return a + b;
		});

		Console.WriteLine("Sum: " + sum);
	}
	public static void GreetUser(string name, Action<string> callback)
	{
		string greeting = $"Hello, {name}!";
		callback(greeting);
	}

	// Func delegate example
	public static int AddNumbers(int a, int b, Func<int, int, int> calculation)
	{
		return calculation(a, b);
	}
}