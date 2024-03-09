namespace ActionAndFuncDelegatesInCsharp;

public class FuncDelegate
{
    private static bool IsWeekend()
    {
        return DateTime.Now.DayOfWeek 
            is ( DayOfWeek.Saturday or DayOfWeek.Sunday ); 
    }

    public static string Func()
    {
        Func<bool> dayOff = IsWeekend;

        return dayOff() ? "Store is closed" : "Store is open";
    }

    public static int FuncParameters(int a, int b)
    {
        Func<int, int, int> sum = (x, y) => x + y;

        return sum(a, b);
    }
}