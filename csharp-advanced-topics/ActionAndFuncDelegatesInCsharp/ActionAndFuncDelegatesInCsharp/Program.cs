namespace ActionAndFuncDelegatesInCsharp
{
	class Program
	{
		static void Main()
		{
			Action<string, int> printDetails = (name, age) =>
				Console.WriteLine($"Name: {name}, Age: {age}");

			printDetails("John Doe", 30);

			Func<string, int, string> greetPerson = (name, age) =>
			{
				return $"Hello, {name}! You are {age} years old.";
			};

			var greeting = greetPerson("Alice", 25);
			Console.WriteLine(greeting);
		}
	}
}
