namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class ReturnClass
{
    public async Task<int> UseReturnMethodAsync()
    {
        Console.WriteLine($"I am in {nameof(UseReturnMethodAsync)} method. About to perform some asynchronous work");

        await Task.Delay(1000);

        return 20;
    }
}