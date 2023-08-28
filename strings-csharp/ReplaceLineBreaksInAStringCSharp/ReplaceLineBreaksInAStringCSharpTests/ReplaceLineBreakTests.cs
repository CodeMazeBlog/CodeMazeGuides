using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpTests;

public class ReplaceLineBreakTests
{
    readonly ReplaceLineBrake replaceLineBrake = new();
    
    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceMethod_ThenReturnStringOnOneLine()
    {
        // Given
        var expected = "This is a line. This is another line.";
        
        // When
        var actual = replaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceMethod();
        
        // Then
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void WhenReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        // Given
        var expected = "This is a line.\nThis is another line.";
        
        // When
        var actual = replaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();
        
        // Then
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void WhenReplaceLineBreaksUsingTheRegularExpressionReplaceMethod_ThenReturnStringWithUpdatedLineEnding()
    {
        // Given
        var expected = "This is a line.&lt;br /&gt;This is another line.";
        
        // When
        var actual = replaceLineBrake.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();
        
        // Then
        Assert.Equal(expected, actual);
    }
}
