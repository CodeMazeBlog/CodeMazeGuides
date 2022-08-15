namespace MultipleTasksDemo.Client.Extensions;

public class TaskExtensions
{
    public static async Task<(T1, T2, T3)> WhenAll<T1, T2, T3>(Task<T1> task1, Task<T2> task2, Task<T3> task3)
    {
        var allTasks = Task.WhenAll(task1, task2, task3);
        try
        {
            await allTasks;
        }
        catch (Exception exp)
        {
            Console.WriteLine("Task Exception", exp);
            throw allTasks.Exception;
        }

        return (task1.Result, task2.Result, task3.Result);
    }
}