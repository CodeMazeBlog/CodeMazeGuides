namespace ActionFuncDelegatesInCsharp.Methods;

public class FuncMethods
{
    public static int Addition(int x, int y)
    {
        return x + y;
    }

    public static string DisplayAddition(int a, int b)
    {
        return $"Addition of {a} and {b} is {a + b}";
    }

    public static string ShowCompleteName(string firstName, string lastName)
    {
        return $"Author of this Article is {firstName} {lastName}";
    }
}