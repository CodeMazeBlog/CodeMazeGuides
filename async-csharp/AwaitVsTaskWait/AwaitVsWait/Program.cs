using AwaitVsWait.Examples;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Await Execution");

        var awaitables = new Awaitables();
        awaitables.Execute();

        Console.WriteLine("Ending Await Execution");

        Console.WriteLine("Starting Task Wait() Execution");

        var tw = new TaskWait();
        tw.Execute();

        Console.WriteLine("Ending Task Wait() Execution");
    }
}