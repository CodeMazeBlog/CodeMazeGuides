using System.Text.RegularExpressions;

namespace ReplaceLineBreaksInAStringCSharp;

public static class ReplaceLineBrake
{
    public static string ReplaceLineBreaksUsingTheStringReplaceMethod()
    {
        const string text = "This is a line.\nThis is another line.";
        return text.Replace("\n", " ");
    }
    
    public static string ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod()
    {
        const string text = "This is a line.\rThis is another line.";
        return text.ReplaceLineEndings("\n");
    }
    
    public static string ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod()
    {
        const string text = "This is a line.\r\nThis is another line.";
        return Regex.Replace(text, @"(\r\n|\n)", "&lt;br /&gt;");
    }
}
