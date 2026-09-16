using ReplaceLineBreaksInAStringCSharp;

var stringReplaceResult = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceMethod();
Console.WriteLine(stringReplaceResult);

var stringReplaceLineEndingsResult = ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();
Console.WriteLine(stringReplaceLineEndingsResult);

var regularExpressionReplaceResult = ReplaceLineBreak.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();
Console.WriteLine(regularExpressionReplaceResult);

var removeLineBreaksResult = ReplaceLineBreak.RemoveLineBreaks();
Console.WriteLine(removeLineBreaksResult);
