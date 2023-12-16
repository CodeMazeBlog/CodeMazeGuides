namespace FuncAndActionDelegate;

public class FuncClass
{
	public static void RunAddNumbers()
	{
		Func<int, int, int> addNumbers = AddNumbers;
		int sum = addNumbers(5, 7);
		Console.WriteLine($"Sum of Numbers: {sum}");
	}

	public static int AddNumbers(int a, int b)
	{
		return a + b;
	}
}