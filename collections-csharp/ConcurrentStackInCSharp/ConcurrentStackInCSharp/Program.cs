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
            () =>
            {
                var actionPerformed = tool.PerformAction("Draw Circle");
                Console.WriteLine(actionPerformed);
                
                Task.Delay(30).Wait();  // Simulating some work

                var actionUndone = tool.UndoLastAction();
                Console.WriteLine(actionUndone);
            },
            () =>
            {
                var actionsPerformed = tool.PerfromMultipleActions(
                    "Draw Square",
                    "Draw Triangle",
                    "Draw Parallel Lines",
                    "Draw Hexagon");
                Console.WriteLine(actionsPerformed);

                Task.Delay(50).Wait();  // Simulating some work

                foreach (var action in tool.UndoLastNActions(4))
                {
                    Console.WriteLine(action);
                }
            },
            () =>
            {
                var actionPerformed = tool.PerformAction("Color Circle Red");
                Console.WriteLine(actionPerformed);

                Task.Delay(70).Wait();  // Simulating some work

                var actionUndone = tool.UndoLastAction();
                Console.WriteLine(actionUndone);
            }
        );
    }
}