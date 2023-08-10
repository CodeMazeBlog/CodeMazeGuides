using ActionAndFuncDelegates;

namespace ActionAndFuncDelegatesTests;

[Collection("ActionAndFuncDelegates")]
public class FuncDelegateTests
{
    private readonly StringWriter _writer;

    public FuncDelegateTests()
    {
        _writer = new StringWriter();
        Console.SetOut(_writer);
    }

    [Fact]
    public void WhenFuncDelegateExample_ThenWritesRightResultToConsole()
    {
        var expectedOutput = "Name: Code Surname: Maze" + Environment.NewLine;

        FuncDelegate.FuncDelegateExample();

        Assert.Equal(expectedOutput, _writer.ToString());
    }

    [Fact]
    public void WhenFuncQueryingWithLinq_ThenWritesRightResultToConsole()
    {
        var expectedEvenNumbers = new List<int> { 2, 4 };

        var evenNumbers = FuncDelegate.FuncQueryingWithLinq();

        Assert.Equal(expectedEvenNumbers, evenNumbers);
    }
}
