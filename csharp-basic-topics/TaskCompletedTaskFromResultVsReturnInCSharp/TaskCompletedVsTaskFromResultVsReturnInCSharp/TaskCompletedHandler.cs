namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class TaskCompletedHandler
{
    public Task UseTaskCompletedAsync()
    {
        Console.WriteLine("Not performing any asynchronous work.");

        return Task.CompletedTask;
    }

    public void UseTaskCompletedSync()
    {
        Console.WriteLine("Performing a synchronous work.");

        Task.CompletedTask.Wait();
    }
}