using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpTests;

public class ReplaceLineBreakTests
{
    private const string Expected = "Line one.\nLine two.\nLine three.\nLine four.";

    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceMethod_ThenReturnStringWithUpdatedLineEndings()
    {
        var actual = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceMethod();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod_ThenReturnStringWithUpdatedLineEndings()
    {
        var actual = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheRegularExpressionReplaceMethod_ThenReturnStringWithUpdatedLineEndings()
    {
        var actual = ReplaceLineBreak.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void WhenRemoveLineBreaks_ThenReturnStringWithNoLineBreaksAtAll()
    {
        var actual = ReplaceLineBreak.RemoveLineBreaks();

        Assert.Equal("Line one.Line two.Line three.Line four.", actual);
    }

    [Fact]
    public void WhenReplacingCarriageReturnBeforeCarriageReturnLineFeed_ThenWindowsLineBreakDoubles()
    {
        const string text = "Line one.\r\nLine two.";

        var wrongOrder = text.Replace("\r", "\n");
        var rightOrder = text.Replace("\r\n", "\n").Replace("\r", "\n");

        Assert.Equal("Line one.\n\nLine two.", wrongOrder);
        Assert.Equal("Line one.\nLine two.", rightOrder);
    }

    [Fact]
    public void WhenTextContainsALineSeparator_ThenOnlyReplaceLineEndingsMatchesIt()
    {
        const string text = "Line one.\u2028Line two.";

        var replaceLineEndings = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod(text);
        var replaceChain = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceMethod(text);

        Assert.Equal("Line one.\nLine two.", replaceLineEndings);
        Assert.Equal(text, replaceChain);
    }
}
