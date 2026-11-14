namespace PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

public static class AsyncLocalReferenceTypeExample
{
    public static readonly AsyncLocal<List<string>> AsyncLocalList = new();

    public static async Task DoWork()
    {
        AsyncLocalList.Value = ["Added in DoWork"];

        await DoSubTask();

        Console.WriteLine($"AsyncLocal list in DoWork method after executing DoSubTask method: " +
            $"{string.Join(", ", AsyncLocalList.Value)}");
    }

    private static async Task DoSubTask()
    {
        AsyncLocalList.Value!.Add("Added in DoSubTask");

        await Task.Delay(100);
    }
}
