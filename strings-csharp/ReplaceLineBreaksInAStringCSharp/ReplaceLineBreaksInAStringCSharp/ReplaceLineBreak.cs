using System.Text.RegularExpressions;

namespace ReplaceLineBreaksInAStringCSharp;

public static class ReplaceLineBreak
{
    public static string ReplaceLineBreaksUsingTheStringReplaceMethod()
    {
        const string text = "This is a line.\rThis is another line.";
        var newText = text.Replace("\r\n", "\n").Replace("\r", "\n");
        
        return newText;
    }

    public static string ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod()
    {
        const string text = "This is a line.\rThis is another line.";
        var newText = text.ReplaceLineEndings("\n");
        
        return newText;
    }

    public static string ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod()
    {
        const string text = "This is a line.\rThis is another line.";
        var newText = Regex.Replace(text, @"(\r\n|\r)", "\n");
        
        return newText;
    }
}
