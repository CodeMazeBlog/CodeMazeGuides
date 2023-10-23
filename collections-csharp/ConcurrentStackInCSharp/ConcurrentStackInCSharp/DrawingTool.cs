using System.Collections.Concurrent;

namespace ConcurrentStackInCSharp;

public class DrawingTool
{
    private readonly ConcurrentStack<string> _actionHistory = new ConcurrentStack<string>();

    public void PerformAction(string action)
    {
        _actionHistory.Push(action);
        Console.WriteLine($"Performed action: {action}");
    }

    public void UndoLastAction()
    {
        if (_actionHistory.TryPop(out var lastAction))
        {
            Console.WriteLine($"Undid action: {lastAction}");
            return;
        }

        Console.WriteLine("No actions to undo.");
    }

    public void PerfromMultipleActions(params string[] actions)
    {
        _actionHistory.PushRange(actions);
        foreach (var action in actions)
        {
            Console.WriteLine($"Performed actions: {action}");
        }
    }

    public void UndoLastNActions(int numberOfActionsToUndo)
    {
        var lastActions = new string[numberOfActionsToUndo];
        var numberOfActionsUndone = _actionHistory.TryPopRange(lastActions);

        if (numberOfActionsUndone > 0)
        {
            Console.WriteLine($"Successfully undid {numberOfActionsUndone} actions");
            return;
        }

        Console.WriteLine("No actions to undo.");
    }
}