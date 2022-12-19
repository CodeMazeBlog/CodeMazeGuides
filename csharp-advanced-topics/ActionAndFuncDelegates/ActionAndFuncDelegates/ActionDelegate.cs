namespace ActionAndFuncDelegatesInCSharp;

public class ActionDelegate
{
    public static void PrintNumbers()
    {
        var p = new TimeSpan(0, 0, 0, 1577923200);

        var numbers = new List<int>() { 1, 2, 3, 4, 5 };

        //var printAction = new Action<int>(Console.WriteLine);
        numbers.ForEach(Console.WriteLine);
    }
}
