namespace PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

public static class AsyncLocalVsThreadLocalExample
{
    private static readonly AsyncLocal<string> AsyncLocalString = new();
    private static readonly ThreadLocal<string> ThreadLocalString = new();

    public static async Task DoWork()
    {
        AsyncLocalString.Value = "Set in DoWork";
        ThreadLocalString.Value = "Set in DoWork";

        var thread = new Thread(() =>
            Console.WriteLine($"New thread, AsyncLocal: {AsyncLocalString.Value}, " +
                $"ThreadLocal: {ThreadLocalString.Value ?? "null"}"));
        thread.Start();
        thread.Join();

        Task task;
        using (ExecutionContext.SuppressFlow())
        {
            task = Task.Run(() =>
                Console.WriteLine($"Task.Run with suppressed flow, AsyncLocal: {AsyncLocalString.Value ?? "null"}"));
        }

        await task;
    }
}
