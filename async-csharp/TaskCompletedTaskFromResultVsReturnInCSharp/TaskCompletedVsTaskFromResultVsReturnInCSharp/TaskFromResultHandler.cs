namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class TaskFromResultHandler
{
    public async Task<string> UseTaskFromResultAsync()
    {
        Console.WriteLine("Not performing any asynchronous work but returning a result.");

        var message = "Hello, world!";

        return await Task.FromResult(message);
    }

    public string UseTaskFromResultSync()
    {
        Console.WriteLine("Performing a synchronous work.");

        var message = "Hello, world!";

        return Task.FromResult(message).Result;
    }
}