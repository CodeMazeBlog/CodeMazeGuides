namespace AsynchronousProgrammingPatterns;

public static class Program
{
    public async static Task Main()
    {
        AsyncProgrammingModelHelper.FetchAndPrintUser(100);

        EventBasedAsyncPatternHelper.FetchAndPrintUser(100);

        await TaskBasedAsyncPatternHelper.FetchAndPrintUser(100);

        Console.ReadKey();
    }
}
