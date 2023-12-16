namespace FuncAndActionDelegate;

public class DelegateClass
{
	public delegate void GreetingDelegate(string message);
	
	public static void PerformGreeting()
	{
		// Create an instance of the GreetingDelegate and invoke it
		var greetingDelegate = new GreetingDelegate(Hello);
		greetingDelegate("Hello from Delegate");
	}

	public static void Hello(string message)
	{
		System.Console.WriteLine($"Hello says: {message}");
	}
}