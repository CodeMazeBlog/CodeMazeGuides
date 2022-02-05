namespace ActionAndFuncDelegates;

public static class ActionClass
{
    public static Action<int> Manipulator;

    public static void Execute(int number)
    {
        Manipulator(number);
    }
}