using AwaitVsWait.Examples;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Await Execution");

        Awaitables awaitables = new Awaitables();
        awaitables.Execute();

        Console.WriteLine("Ending Await Execution");

        Console.WriteLine("Starting Task Wait() Execution");

        TaskWait tw = new TaskWait();
        tw.Execute();

        Console.WriteLine("Ending Task Wait() Execution");
    }
}