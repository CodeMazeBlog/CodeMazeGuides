using ActionAndFuncDelegates;

namespace ActionAndFuncDelegatesTests;

[Collection("ActionAndFuncDelegates")]
public class ActionDelegateTests
{
    private readonly StringWriter _writer;

    public ActionDelegateTests()
    {
        _writer = new StringWriter();
        Console.SetOut(_writer);
    }

    [Fact]
    public void WhenActionDelegateExample_ThenWritesRightResultToConsole()
    {
        var expectedOutput = "Name: Code Surname: Maze" + Environment.NewLine;

        ActionDelegate.ActionDelegateExample();

        Assert.Equal(expectedOutput, _writer.ToString());
    }

    [Fact]
    public void WhenActionIterationOverCollections_ThenWritesRightResultToConsole()
    {
        var expectedOutput = "1" + Environment.NewLine +
                             "4" + Environment.NewLine +
                             "9" + Environment.NewLine +
                             "16" + Environment.NewLine;

        ActionDelegate.ActionIterationOverCollections();

        Assert.Equal(expectedOutput, _writer.ToString());
    }

    [Fact]
    public void WhenActionEventHandling_ThenWritesRightResultToConsole()
    {
        var expectedOutput = "Code Maze" + Environment.NewLine +
                             "Another: Code Maze" + Environment.NewLine;

        ActionDelegate.ActionEventHandling();

        Assert.Equal(expectedOutput, _writer.ToString());
    }

    [Fact]
    public void WhenActionInvoke_ThenWritesRightResultToTheConsole()
    {
        var expectedOutput1 = "Action 1" + Environment.NewLine + "Action 2" + Environment.NewLine;
        var expectedOutput2 = "Action 2" + Environment.NewLine + "Action 1" + Environment.NewLine;

        ActionDelegate.ActionInvoke();

        var actualOutput = _writer.ToString();
        Assert.True(actualOutput == expectedOutput1 || actualOutput == expectedOutput2);
    }
}