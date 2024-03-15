using System.Collections.Concurrent;

namespace ConcurrentStackInCSharp;

public class DrawingTool
{
    private readonly ConcurrentStack<string> _actionHistory = new();

    public string PerformAction(string action)
    {
        _actionHistory.Push(action);

        return $"Performed action: {action}";
    }

    public string UndoLastAction()
    {
        if (!_actionHistory.TryPop(out var lastAction))
            return "No action to undo";

        return $"Undid action: {lastAction}";
    }


    public string PerfromMultipleActions(params string[] actions)
    {
        _actionHistory.PushRange(actions);
        return $"Performed actions: {string.Join(", ",actions.ToArray())}";
    }

    public IEnumerable<string> UndoLastNActions(int numberOfActionsToUndo)
    {
        var lastActions = new string[numberOfActionsToUndo];
        var actionsUndoneCount = _actionHistory.TryPopRange(lastActions);

        if (actionsUndoneCount == 0)
        {
            yield return "Failed to undo actions";
        }

        for (int i = 0; i < actionsUndoneCount; i++)
        {
            yield return $"Undid action: {lastActions[i]}";
        }
    }
}