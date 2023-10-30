using System.Collections.Concurrent;

namespace ConcurrentStackInCSharp;

public class DrawingTool
{
    private readonly ConcurrentStack<string> _actionHistory = new();

    public void PerformAction(string action)
    {
        _actionHistory.Push(action);
    }

    public string UndoLastAction()
    {
        if(_actionHistory.Count==0)
            return "No action to undo";

        if (!_actionHistory.TryPop(out var lastAction))
        {
            throw new Exception("Failed to Pop last action");
        }

        return $"Undid action: {lastAction}";
    }


    public int PerfromMultipleActions(params string[] actions)
    {
        _actionHistory.PushRange(actions);
        return _actionHistory.Count;
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