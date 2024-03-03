using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]

namespace DifferenceBetweenAwaitAndTaskWaitInCsharp;

internal class Program
{
    static async Task Main(string[] args)
    {
        BlockingCodeExample();
        await AsynchronousCodeExample();

        await AsynchronousExceptionHandling();

        BlockingExceptionHandling();
    }

    internal static void BlockingCodeExample()
    {
        Console.WriteLine("** Blocking code Example **");

        Console.WriteLine($"Current ManagedThreadId: {Environment.CurrentManagedThreadId}");
        Task<string> taskToBlock = Task<string>.Run(() =>
        {
            Thread.Sleep(5000);
            return "Hello, from a blocking task";
        });
        taskToBlock.Wait();
        string blockingResult = taskToBlock.Result;
        Console.WriteLine($"Current ManagedThreadId: {Environment.CurrentManagedThreadId}");
    }

    internal static void BlockingExceptionHandling()
    {
        Console.WriteLine("** Blocking Exception Handling **");

        try
        {
            Task taskToFail = Task.Run(() =>
            {
                throw new ApplicationException("Error in the blocking long-running operation");
            });
            taskToFail.Wait();
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    internal async static Task AsynchronousCodeExample()
    {
        Console.WriteLine("** Asynchronous code Example **");

        Console.WriteLine($"Current ManagedThreadId: {Environment.CurrentManagedThreadId}");
        Task<string> taskToAwait = Task<string>.Run(() =>
        {
            Thread.Sleep(5000);
            return "Hello, from an asyncrhonous task";
        });
        string awaitResult = await taskToAwait;
        Console.WriteLine($"Current ManagedThreadId: {Environment.CurrentManagedThreadId}");
    }

    internal async static Task AsynchronousExceptionHandling()
    {
        Console.WriteLine("** Asynchronous Exception Handling **");

        try
        {
            Task taskToFail = Task.Run(() =>
            {
                throw new ApplicationException("Error in the asynchronous long-running operation");
            });
            await taskToFail;
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
