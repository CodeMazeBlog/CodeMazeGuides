namespace ConcurrentStackInCSharp;

public class Program
{
    public static async Task Main()
    {
        await ConsoleWriteLineAsync("Simulating usage of Drawing tool...");
        await UseDrawingTool();
    }

    public static async Task UseDrawingTool()
    {
        DrawingTool tool = new();

        var task1 = Task.Run(async () =>
        {
            var performedAction = tool.PerformAction("Draw Circle");
            await ConsoleWriteLineAsync(performedAction);

            var actionUndone = tool.UndoLastAction();
            await ConsoleWriteLineAsync(actionUndone);
        });

        var task2 = Task.Run(async () =>
        {
            var performedActions = tool.PerfromMultipleActions(
                "Draw Square",
                "Draw Triangle",
                "Draw Parallel Lines",
                "Draw Hexagon");
            await ConsoleWriteLineAsync(performedActions);

            foreach (var action in tool.UndoLastNActions(4))
            {
                await ConsoleWriteLineAsync(action);
            }
        });

        var task3 = Task.Run(async () =>
        {
            var performedAction = tool.PerformAction("Color Circle Red");
            await ConsoleWriteLineAsync(performedAction);

            var actionUndone = tool.UndoLastAction();
            await ConsoleWriteLineAsync(actionUndone);
        });

        await Task.WhenAll(task1, task2, task3);
    }

    private static async Task ConsoleWriteLineAsync(string message)
    {
        await Task.Run(() => Console.WriteLine(message));
    }
}
