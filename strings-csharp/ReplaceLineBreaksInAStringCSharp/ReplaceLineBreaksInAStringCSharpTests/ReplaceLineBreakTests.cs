using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpTests;

public class ReplaceLineBreakTests
{
    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceMethod_ThenReturnStringOnOneLine()
    {
        const string expected = "This is a line. This is another line.";

        var actual = ReplaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceMethod();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        const string expected = "This is a line.\nThis is another line.";

        var actual = ReplaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheRegularExpressionReplaceMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        const string expected = "This is a line.&lt;br /&gt;This is another line.";

        var actual = ReplaceLineBrake.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();

        Assert.Equal(expected, actual);
    }
}
