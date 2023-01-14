namespace EventBasedAsyncPattern;

public static class Program
{
    public static void Main()
    {
        EventBasedAsyncPatternHelper.FetchAndPrintUser(100);

        Console.ReadKey();
    }
}
