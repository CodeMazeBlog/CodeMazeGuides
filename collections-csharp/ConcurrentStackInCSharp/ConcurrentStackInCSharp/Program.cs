using ConcurrentStackInCSharp;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Simulate usage of Drawing tool..");
        UseDrawingTool();
    }

    public static void UseDrawingTool()
    {
        DrawingTool tool = new DrawingTool();

        // Simulate multiple users performing and undoing actions concurrently
        Parallel.Invoke(
            () =>
            {
                tool.PerformAction("Draw Circle");
                Task.Delay(50).Wait();  // Simulating some work
                tool.UndoLastAction();
            },
            () =>
            {
                tool.PerfromMultipleActions("Draw Square", "Draw Triangle", "Draw Parallel Lines", "Draw Hexagon");
                Task.Delay(30).Wait();  // Simulating some work
                tool.UndoLastNActions(4); // Undo last 4 actions
            },
            () =>
            {
                tool.PerformAction("Color Circle Red");
                Task.Delay(70).Wait();  // Simulating some work
                tool.UndoLastAction();
            }
        );
    }
}