namespace ActionAndFuncDelegates;

public static class FuncClass
{
    public static Func<int, int> Manipulate;

    public static void Execute(int number)
    {
        Console.WriteLine(Manipulate(number));
    }
}
