namespace TaskCompletedVsTaskFromResultVsReturnInCSharp;

public class TaskCompletedClass
{
    public Task UseTaskCompletedMethodAsync()
    {
        Console.WriteLine($"I am in {nameof(UseTaskCompletedMethodAsync)} method. Not performing any asynchronous work.");

        return Task.CompletedTask;
    }
}