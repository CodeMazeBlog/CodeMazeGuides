using ConcurrentStackInCSharp;

namespace Tests;

public class DrawingToolTests
{
    [Fact]
    public void When_NoActionPerformed_Then_UndoLastActionReturnsNoActionMessage()
    {
        // Arrange
        var tool = new DrawingTool();

        // Act
        var result = tool.UndoLastAction();

        // Assert
        Assert.Equal("No action to undo", result);
    }

    [Fact]
    public void When_SingleActionPerformed_Then_UndoLastActionReturnsThatAction()
    {
        // Arrange
        var tool = new DrawingTool();
        var action = "Draw Circle";

        // Act
        tool.PerformAction(action);
        var result = tool.UndoLastAction();

        // Assert
        Assert.Equal($"Undid action: {action}", result);
    }

    [Fact]
    public void When_MultipleActionsPerformed_Then_UndoLastActionReturnsLastAction()
    {
        // Arrange
        var tool = new DrawingTool();
        var actions = new[] { "Draw Circle", "Draw Square", "Color Circle Red" };

        // Act
        tool.PerfromMultipleActions(actions);
        var result = tool.UndoLastAction();

        // Assert
        Assert.Equal($"Undid action: {actions[actions.Length-1]}", result);
    }

    [Fact]
    public void When_PerformMultipleActions_Then_CountIncreasesAccordingly()
    {
        // Arrange
        var tool = new DrawingTool();
        var actions = new[] { "Draw Circle", "Draw Square", "Color Circle Red" };

        // Act
        var output = tool.PerfromMultipleActions(actions);

        // Assert
        Assert.Equal($"Performed actions: {string.Join(", ", actions.ToArray())}", output);
    }

    [Fact]
    public void When_UndoingMultipleActions_Then_ReturnsCorrectNumberOfActions()
    {
        // Arrange
        var tool = new DrawingTool();
        var actions = new[] { "Draw Circle", "Draw Square", "Color Circle Red" };
        tool.PerfromMultipleActions(actions);

        // Act
        var undoneActions = tool.UndoLastNActions(2).ToList();

        // Assert
        Assert.Equal(2, undoneActions.Count);
        Assert.Contains($"Undid action: {actions[actions.Length - 1]}", undoneActions);
        Assert.Contains($"Undid action: {actions[actions.Length - 2]}", undoneActions);
    }

    [Fact]
    public void When_UndoingMoreActionsThanAvailable_Then_ReturnsAllActions()
    {
        // Arrange
        var tool = new DrawingTool();
        var actions = new[] { "Draw Circle", "Draw Square" };
        tool.PerfromMultipleActions(actions);

        // Act
        var undoneActions = tool.UndoLastNActions(4).ToList();

        // Assert
        Assert.Equal(actions.Length, undoneActions.Count);
        Assert.Contains($"Undid action: {actions[actions.Length - 1]}", undoneActions);
        Assert.Contains($"Undid action: {actions[0]}", undoneActions);
    }

    [Fact]
    public void When_UndoingWithNoActions_Then_ReturnsFailureMessage()
    {
        // Arrange
        var tool = new DrawingTool();

        // Act
        var undoneActions = tool.UndoLastNActions(2).ToList();

        // Assert
        Assert.Single(undoneActions);
        Assert.Equal("Failed to undo actions", undoneActions[0]);
    }
}
