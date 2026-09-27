namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class TaskFromResultHandler
{
    public Task<string> UseTaskFromResultAsync()
    {
        Console.WriteLine("Not performing any asynchronous work but returning a result.");

        var message = "Hello, world!";

        return Task.FromResult(message);
    }
}