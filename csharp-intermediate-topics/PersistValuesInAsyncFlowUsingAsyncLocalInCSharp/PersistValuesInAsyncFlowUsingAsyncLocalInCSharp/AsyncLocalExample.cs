namespace PersistValuesInAsyncFlowUsingAsyncLocalInCSharp;

public static class AsyncLocalExample
{
    public static readonly AsyncLocal<int> AsyncLocalInt = new();

    public static async Task DoWork()
    {
        AsyncLocalInt.Value = 1;
        Console.WriteLine($"AsyncLocal value in DoMainWork method: {AsyncLocalInt.Value}");

        await DoSubTaskLevel1();

        Console.WriteLine($"AsyncLocal value in DoMainWork method after executing " +
            $"DoSubTaskLevel1 method: {AsyncLocalInt.Value}");
    }

    private static async Task DoSubTaskLevel1()
    {
        Console.WriteLine($"AsyncLocal value when entering DoSubTaskLevel1 method: {AsyncLocalInt.Value}");

        AsyncLocalInt.Value++;
        Console.WriteLine($"AsyncLocal value after changing in DoSubTaskLevel1 method: {AsyncLocalInt.Value}");

        await DoSubTaskLevel2();

        Console.WriteLine($"AsyncLocal value in DoSubTaskLevel1 method after executing " +
            $"DoSubTaskLevel2 method: {AsyncLocalInt.Value}");
    }

    private static async Task DoSubTaskLevel2()
    {
        Console.WriteLine($"AsyncLocal value when entering DoSubTaskLevel2 method: {AsyncLocalInt.Value}");

        AsyncLocalInt.Value++;
        Console.WriteLine($"AsyncLocal value after changing in DoSubTaskLevel2 method: {AsyncLocalInt.Value}");

        await Task.Delay(100);
    }
}
