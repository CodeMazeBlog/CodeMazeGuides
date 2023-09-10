namespace ReplaceLineBreaksInAStringCSharp;

class Program
{
    static void Main(string[] args)
    {
        var stringReplaceResult = ReplaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceMethod();
        Console.WriteLine(stringReplaceResult);

        var stringReplaceLineEndingsResult = ReplaceLineBrake.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();
        Console.WriteLine(stringReplaceLineEndingsResult);

        var regularExpressionReplaceResult = ReplaceLineBrake.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();
        Console.WriteLine(regularExpressionReplaceResult);
    }
}
