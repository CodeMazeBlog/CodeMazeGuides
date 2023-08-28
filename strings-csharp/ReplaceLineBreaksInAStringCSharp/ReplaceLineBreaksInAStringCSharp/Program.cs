using System.Text.RegularExpressions;

namespace ReplaceLineBreaksInAStringCSharp;

class Program
{
    static void Main(string[] args)
    {
        var stringReplaceResult = new ReplaceLineBrake().ReplaceLineBreaksUsingTheStringReplaceMethod();
        Console.WriteLine(stringReplaceResult);
        
        var stringReplaceLineEndingsResult = new ReplaceLineBrake().ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();
        Console.WriteLine(stringReplaceLineEndingsResult);
        
        var regularExpressionReplaceResult = new ReplaceLineBrake().ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();
        Console.WriteLine(regularExpressionReplaceResult);
    }
}

public class ReplaceLineBrake
{
    public string ReplaceLineBreaksUsingTheStringReplaceMethod()
    {
        var text = "This is a line.\nThis is another line.";
        var newText = text.Replace("\n", " ");
        
        return newText;
    }
    
    public string ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod()
    {
        var text = "This is a line.\rThis is another line.";
        var newText = text.ReplaceLineEndings("\n");
        
        return newText;
    }
    
    public string ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod()
    {
        var text = "This is a line.\r\nThis is another line.";
        var newText = Regex.Replace(text, @"(\r\n|\n)", "&lt;br /&gt;");

        return newText;
    }
}

