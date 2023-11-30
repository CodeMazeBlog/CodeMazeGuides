namespace FuncAndActionDelegate;

public class ActionClass
{
	public static void RunMyActionMethod()
	{
		Action<int, string> actionDelegate = MyActionMethod; 
		actionDelegate(42, "Hello");
	}

	public static void MyActionMethod(int number, string message)
	{
		Console.WriteLine($"Received parameters: {number}, {message}");
	}
}