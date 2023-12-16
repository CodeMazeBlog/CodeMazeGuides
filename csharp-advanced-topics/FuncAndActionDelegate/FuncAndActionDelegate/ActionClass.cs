namespace FuncAndActionDelegate;

public class ActionClass
{
	public static void RunMyAction()
	{
		Action<int, string> actionDelegate = MyAction; 
		actionDelegate(42, "Hello");
	}

	public static void MyAction(int number, string message)
	{
		Console.WriteLine($"Received parameters: {number}, {message}");
	}
}