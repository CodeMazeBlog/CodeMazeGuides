namespace ActionAndFuncDelegates;

public delegate void Writer(string message);

public static class DelegateClass
{
    public static Writer Writers;

    public static void Execute(string message)
    {
        Writers(message);
    }
}
