using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpTests;

public class ReplaceLineBreakTests
{
    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceMethod_ThenReturnStringOnOneLine()
    {
        // Given
        const string expected = "This is a line. This is another line.";

        // When
        var actual = ReplaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceMethod();

        // Then
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        // Given
        const string expected = "This is a line.\nThis is another line.";

        // When
        var actual = ReplaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();

        // Then
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenReplaceLineBreaksUsingTheRegularExpressionReplaceMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        // Given
        const string expected = "This is a line.&lt;br /&gt;This is another line.";

        // When
        var actual = ReplaceLineBrake.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();

        // Then
        Assert.Equal(expected, actual);
    }
}
