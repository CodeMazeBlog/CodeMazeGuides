namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class ReturnHandler
{
    public async Task<int> UseReturnAsync()
    {
        Console.WriteLine("About to perform some asynchronous work.");

        await Task.Delay(1000);

        return 20;
    }
}