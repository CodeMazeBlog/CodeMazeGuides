using BenchmarkDotNet.Running;
using StringTruncationInCSharp;

var originalString = "This is a long string.";
var maxLength = 10;

var truncatedUsingSubstring = StringHelper.TruncateWithSubstring(originalString, maxLength);
Console.WriteLine("Using Substring method: " + truncatedUsingSubstring);

var truncatedUsingForLoop = StringHelper.TruncateWithForLoop(originalString, maxLength);
Console.WriteLine("Using For Loop: " + truncatedUsingForLoop);

var truncatedUsingStringBuilder = StringHelper.TruncateWithForLoopStringBuilder(originalString, maxLength);
Console.WriteLine("Using StringBuilder: " + truncatedUsingStringBuilder);

var truncatedUsingRegularExpressions = StringHelper.TruncateWithRegularExpressions(originalString, maxLength);
Console.WriteLine("Using Regular Expressions: " + truncatedUsingRegularExpressions);

var truncatedUsingRemove = StringHelper.TruncateWithRemove(originalString, maxLength);
Console.WriteLine("Using Remove method: " + truncatedUsingRemove);

var truncatedUsingLINQ = StringHelper.TruncateWithLINQ(originalString, maxLength);
Console.WriteLine("Using LINQ: " + truncatedUsingLINQ);

var truncatedUsingExtensionMethod = originalString.TruncateString(maxLength);
Console.WriteLine("Using Extension method: " + truncatedUsingExtensionMethod);

BenchmarkRunner.Run<StringHelperBenchmark>();