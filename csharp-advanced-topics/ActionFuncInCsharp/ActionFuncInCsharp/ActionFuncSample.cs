public class ActionFuncSample
{
    public static void CallAnAction(Action action)
    {
        Console.WriteLine("***CallAnAction will call an action:***");

        action();

        Console.WriteLine("***Action Delegate executed.***");
    }

    public static void CallAFunc(Func<bool> func)
    {
        Console.WriteLine("***CallAFunc will call a func:***");

        bool result = func();

        Console.WriteLine($"***Func result is {result}***");
    }
}
