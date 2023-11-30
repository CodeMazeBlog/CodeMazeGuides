namespace FuncAndActionDelegate;

public class FuncClass
{
	public static void RunAddNumbers()
	{
		Func<int, int, int> addNumbers = AddNumbersMethod;
		int sum = addNumbers(5, 7);
		Console.WriteLine("Sum of Numbers: " + sum);
	}

	public static int AddNumbersMethod(int a, int b)
	{
		return a + b;
	}
}