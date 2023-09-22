using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpTests;

public class ReplaceLineBreakTests
{
    private const string Expected = "This is a line.\nThis is another line.";
    
    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceMethod_ThenReturnStringOnOneLine()
    {
        var actual = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceMethod();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        var actual = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheRegularExpressionReplaceMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        var actual = ReplaceLineBreak.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();

        Assert.Equal(Expected, actual);
    }
}
