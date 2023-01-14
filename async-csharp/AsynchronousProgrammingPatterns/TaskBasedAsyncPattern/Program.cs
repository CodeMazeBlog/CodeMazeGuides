namespace TaskBasedAsyncPattern;

public static class Program
{
    public async static Task Main()
    {
        await TaskBasedAsyncPatternHelper.FetchAndPrintUser(100);

        Console.ReadKey();
    }
}
