namespace AsynchronousProgrammingPatterns;

public static class Program
{
    public static async Task Main()
    {
        EventBasedAsyncPatternHelper.FetchAndPrintUser(100);

        await TaskBasedAsyncPatternHelper.FetchAndPrintUser(100);

        Console.ReadKey();
    }
}
