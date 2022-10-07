namespace aspnetcore_action_func_delegates.ActionDelegate;

public static class MyDelegateAction
{
    // Define a method to calculate my age
    public static void CalculAge(int year)
    {
        Console.WriteLine($"Your age is {DateTime.Now.Year - year}");
    }

    public static void MainAction()
    {
        Console.WriteLine("Example for an Action<T> delegate");

        // Define scenario to use the Action<T> delegate
        Action<int> actionDelegate = CalculAge;

        // Show the result in the console
        actionDelegate(2005);
    }
}
