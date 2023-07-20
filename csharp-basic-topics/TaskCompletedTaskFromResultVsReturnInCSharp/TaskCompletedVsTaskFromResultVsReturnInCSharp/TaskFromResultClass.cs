namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class TaskFromResultClass
{
    public async Task<string> UseTaskFromResultMethodAsync()
    {
        Console.WriteLine($"I am in {nameof(UseTaskFromResultMethodAsync)} method. Not performing any asynchronous work but returning a result.");

        var message = "Hello, world!";

        return await Task.FromResult(message);
    }
}