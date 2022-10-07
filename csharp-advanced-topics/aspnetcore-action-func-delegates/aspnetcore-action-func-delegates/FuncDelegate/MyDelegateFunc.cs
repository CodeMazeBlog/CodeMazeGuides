namespace aspnetcore_action_func_delegates.FuncDelegate;

public static class MyDelegateFunc
{
    // Define a method to calculate my age
    public static int CalculAge(int year)
    {
        return DateTime.Now.Year - year;
    }

    public static void MainFunc()
    {
        Console.WriteLine("Example for an Func<T> delegate");

        // Define scenario to use the Action<T> delegate
        Func<int, int> funcDelegate = CalculAge;

        // Show the result in the console.
        Console.WriteLine($"Your age is {funcDelegate(2010)}");
    }
}
