namespace PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

public static class AsyncLocalNotifyExample
{
    public static readonly AsyncLocal<string> AsyncLocalString = new(AsyncLocalValueChangedAction);

    static Action<AsyncLocalValueChangedArgs<string>> AsyncLocalValueChangedAction =>
        asyncLocalValueChangedArgs => Console.WriteLine($"Current: {asyncLocalValueChangedArgs.CurrentValue}, " +
                               $"Previous: {asyncLocalValueChangedArgs.PreviousValue}, " +
                               $"Thread: {Environment.CurrentManagedThreadId}, " +
                               $"ThreadContextChanged: {asyncLocalValueChangedArgs.ThreadContextChanged}");

    public static async Task DoWork()
    {
        AsyncLocalString.Value = "Enter DoWork method";
        await DoSubTaskLevel1();
        AsyncLocalString.Value = "Exit DoWork method";
    }

    private static async Task DoSubTaskLevel1()
    {
        AsyncLocalString.Value = "Enter DoSubTaskLevel1 method";
        await DoSubTaskLevel2();
        AsyncLocalString.Value = "Exit DoSubTaskLevel1 method";
    }

    private static async Task DoSubTaskLevel2()
    {
        AsyncLocalString.Value = "Enter DoSubTaskLevel2 method";
        await Task.Delay(100);
        AsyncLocalString.Value = "Exit DoSubTaskLevel2 method";
    }
}
