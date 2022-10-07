namespace aspnetcore_action_func_delegates.DelegateClass;

public static class MyDelegateClass
{
    // Declare a delegate for a method
    public delegate void CalculateMyAge(int year);

    // Define a method to calculate my age
    public static void CalculAge(int year)
    {
        Console.WriteLine($"Your age is {DateTime.Now.Year - year}");
    }

    public static void MainDelegateClass()
    {
        Console.WriteLine("Example for delegate type");

        // Define scenario to use the Action<T> delegate
        CalculateMyAge calculateMyAge = new CalculateMyAge(CalculAge);

        // Show the result in the console
        calculateMyAge(2000);
    }
}