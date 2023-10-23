using ConcurrentStackInCSharp;

namespace Tests;

public class DrawingToolTests
{
    private readonly DrawingTool _drawingTool;
    private readonly StringWriter _stringWriter;

    public DrawingToolTests()
    {
        _drawingTool = new DrawingTool();
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
    }

    [Fact]
    public void WhenPerformingSingleAction_ThenActionIsRegistered()
    {
        _drawingTool.PerformAction("Draw Circle");

        string output = _stringWriter.ToString();
        Assert.Contains("Performed action: Draw Circle", output);
    }

    [Fact]
    public void WhenPerformingMultipleActions_ThenAllActionsAreRegistered()
    {
        _drawingTool.PerfromMultipleActions("Draw Circle", "Draw Square", "Color Circle Red");

        string output = _stringWriter.ToString();
        Assert.Contains("Performed actions: Draw Circle", output);
        Assert.Contains("Performed actions: Draw Square", output);
        Assert.Contains("Performed actions: Color Circle Red", output);
    }

    [Fact]
    public void WhenUndoingLastAction_ThenLastActionIsUndone()
    {
        _drawingTool.PerformAction("Draw Circle");
        _drawingTool.UndoLastAction();

        string output = _stringWriter.ToString();
        Assert.Contains("Undid action: Draw Circle", output);
    }

    [Fact]
    public void WhenUndoingLastNActions_ThenCorrectNumberOfActionsAreUndone()
    {
        _drawingTool.PerfromMultipleActions("Draw Circle", "Draw Square", "Color Circle Red");
        _drawingTool.UndoLastNActions(2);

        string output = _stringWriter.ToString();
        Assert.Contains("Successfully undid 2 actions", output);
    }

    [Fact]
    public void WhenUndoingMoreActionsThanExist_ThenAllActionsAreUndone()
    {
        _drawingTool.PerformAction("Draw Circle");
        _drawingTool.UndoLastNActions(5);

        string output = _stringWriter.ToString();
        Assert.Contains("Successfully undid 1 actions", output);
    }

    [Fact]
    public void WhenUndoingWithoutActions_ThenNoActionsToUndoMessageIsDisplayed()
    {
        _drawingTool.UndoLastAction();

        string output = _stringWriter.ToString();
        Assert.Contains("No actions to undo.", output);
    }

    [Fact]
    public void WhenPerformingConcurrentActions_ThenAllActionsAreRegistered()
    {
        Parallel.Invoke(
            () => _drawingTool.PerformAction("Draw Circle"),
            () => _drawingTool.PerformAction("Draw Square"),
            () => _drawingTool.PerformAction("Color Circle Red"));

        string output = _stringWriter.ToString();
        var actions = new[] { "Draw Circle", "Draw Square", "Color Circle Red" };
        foreach (var action in actions)
        {
            Assert.Contains($"Performed action: {action}", output);
        }
    }

    [Fact]
    public void WhenUndoingActionsConcurrently_ThenAllActionsAreUndoneOrNoActionsToUndoMessageIsDisplayed()
    {
        _drawingTool.PerfromMultipleActions("Draw Circle", "Draw Square", "Color Circle Red");

        Parallel.Invoke(
            () => _drawingTool.UndoLastAction(),
            () => _drawingTool.UndoLastAction(),
            () => _drawingTool.UndoLastAction(),
            () => _drawingTool.UndoLastAction());

        string output = _stringWriter.ToString();
        Assert.True(output.Contains("No actions to undo.") || output.Contains("Undid action:"));
    }

    [Fact]
    public void WhenUndoingMoreActionsThanAvailable_ThenUndoOnlyTheAvaiableActions()
    {
        var tool = new DrawingTool();

        tool.PerformAction("Draw Circle");

        var output = CaptureConsoleOutput(() => 
        {
            tool.UndoLastNActions(5);  // Attempting to undo more actions than available
        });

        Assert.NotEqual("Successfully undid 5 actions", output);
    }

    [Fact]
    public void WhenUndoingFromEmptyStack_ThenNoActionsMessageIsShown()
    {
        var tool = new DrawingTool();

        var output = CaptureConsoleOutput(tool.UndoLastAction);

        Assert.Contains("No actions to undo.", output);
    }

    [Fact]
    public void WhenConcurrentUsersPerformAndUndoActions_ThenNoErrorsOccurAndOutputIsConsistent()
    {
        var tool = new DrawingTool();
        
        Parallel.Invoke(
            () =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    tool.PerformAction($"User1_Action_{i}");
                    tool.UndoLastAction();
                }
            },
            () =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    tool.PerformAction($"User2_Action_{i}");
                    tool.UndoLastAction();
                }
            }
        );

        // If there are any residual actions in the stack at this point, it implies there was an issue with concurrency.
        var output = CaptureConsoleOutput(tool.UndoLastAction);
        Assert.Contains("No actions to undo.", output);
    }

    private string CaptureConsoleOutput(Action action)
    {
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        action.Invoke();
        return consoleOutput.ToString();
    }
}

