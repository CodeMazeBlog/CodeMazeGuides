using System.Collections.Concurrent;

namespace ConcurrentStackInCSharp;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Simulating usage of Drawing tool...");
        UseDrawingTool();
    }

    public static void UseDrawingTool()
    {
        DrawingTool tool = new();

        // Simulate multiple users performing and undoing actions concurrently
        Parallel.Invoke(
            async () =>
            {
                tool.PerformAction("Draw Circle");
                Task.Delay(50).Wait();  // Simulating some work

                var actionUndone = tool.UndoLastAction();
                await ConsoleWriteLineAsync(actionUndone);
            },
            async () =>
            {
                tool.PerfromMultipleActions(
                    "Draw Square",
                    "Draw Triangle",
                    "Draw Parallel Lines",
                    "Draw Hexagon");
                Task.Delay(30).Wait();  // Simulating some work

                foreach (var action in tool.UndoLastNActions(4))
                {
                    await ConsoleWriteLineAsync(action);
                }
            },
            async () =>
            {
                tool.PerformAction("Color Circle Red");
                Task.Delay(70).Wait();  // Simulating some work

                var actionUndone = tool.UndoLastAction();
                await ConsoleWriteLineAsync(actionUndone);
            }
        );
    }

    static Task ConsoleWriteLineAsync(string message)
    {
        return Task.Run(() => Console.WriteLine(message));
    }
}