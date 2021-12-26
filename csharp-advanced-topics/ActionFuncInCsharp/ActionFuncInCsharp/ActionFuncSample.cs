public class ActionFuncSample
{
    public static void CallAnAction(Action action)
    {
        Console.WriteLine("***CallAnAction will call an action:***");

        action();

        Console.WriteLine("***Action Delegate executed.***");
    }

    public static void CallAnActionWithParameters(Action<int, string> actionWithParameters)
    {
        Console.WriteLine("***CallAnActionWithParameters will call an action with parameters:***");

        actionWithParameters(1, "abc");

        Console.WriteLine("***Action Delegate executed.***");
    }

    public static void CallAFunc(Func<bool> func)
    {
        Console.WriteLine("***CallAFunc will call a func:***");

        bool result = func();

        Console.WriteLine($"***Func result is {result}***");
    }

    public static void CallAFuncWithParameters(Func<int, string, bool> funcWithParameters)
    {
        Console.WriteLine("***CallAFuncWithParameters will call a func with Parameters:***");

        bool result = funcWithParameters(1,"abc");

        Console.WriteLine($"***Func result is {result}***");
    }
}
