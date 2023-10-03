using Xunit;

namespace ActionAndFuncDelegatesInCSharpTests;

public class ActionAndFuncDelegatesTests : IDisposable
{
    private readonly StringWriter _stringWriter;
    private readonly TextWriter _originalOutput;

    public ActionAndFuncDelegatesTests()
    {
        _stringWriter = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_stringWriter);
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        _stringWriter.Dispose();
    }

    [Fact]
    public void WhenActionExample_ThenPrintValidString()
    {
        // Arrange
        var expected = "Preparing Hardware: Mouse";

        // Act
        Program.ActionExample();

        // Assert
        Assert.Equal(expected, _stringWriter.ToString().Trim());
    }
}
