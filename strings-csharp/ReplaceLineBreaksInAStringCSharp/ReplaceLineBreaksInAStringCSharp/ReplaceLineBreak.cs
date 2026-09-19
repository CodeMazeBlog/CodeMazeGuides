using System.Text.RegularExpressions;

namespace ReplaceLineBreaksInAStringCSharp;

public static partial class ReplaceLineBreak
{
    public const string Text = "Line one.\r\nLine two.\nLine three.\rLine four.";

    public static string ReplaceLineBreaksUsingTheStringReplaceMethod() =>
        ReplaceLineBreaksUsingTheStringReplaceMethod(Text);

    public static string ReplaceLineBreaksUsingTheStringReplaceMethod(string text) =>
        text.Replace("\r\n", "\n").Replace("\r", "\n");

    public static string ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod() =>
        ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod(Text);

    public static string ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod(string text) =>
        text.ReplaceLineEndings("\n");

    public static string ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod() =>
        ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod(Text);

    public static string ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod(string text) =>
        LineBreakRegex().Replace(text, "\n");

    public static string RemoveLineBreaks() =>
        RemoveLineBreaks(Text);

    public static string RemoveLineBreaks(string text) =>
        text.ReplaceLineEndings(string.Empty);

    [GeneratedRegex(@"\r\n|\r|\n")]
    private static partial Regex LineBreakRegex();
}
