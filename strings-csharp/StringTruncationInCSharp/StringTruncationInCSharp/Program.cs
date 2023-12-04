using BenchmarkDotNet.Running;
using StringTruncationInCSharp;


StringHelper stringHelper = new StringHelper();
var originalString = "This is a long string.";
var maxLength = 10;

var truncatedString_substring = stringHelper.TruncateWithSubstring(originalString, maxLength);
Console.WriteLine("Using Substring method: " + truncatedString_substring);

var truncatedString_forLoop = stringHelper.TruncateWithForLoop(originalString, maxLength);
Console.WriteLine("Using For Loop: " + truncatedString_forLoop);

var truncatedString_stringBuilder = stringHelper.TruncateWithForLoopStringBuilder(originalString, maxLength);
Console.WriteLine("Using StringBuilder: " + truncatedString_stringBuilder);

var truncatedString_regularExpressions = stringHelper.TruncateWithRegularExpressions(originalString, maxLength);
Console.WriteLine("Using Regular Expressions: " + truncatedString_regularExpressions);

var truncatedString_remove = stringHelper.TruncateWithRemove(originalString, maxLength);
Console.WriteLine("Using Remove method: " + truncatedString_remove);

var truncatedString_LINQ = stringHelper.TruncateWithLINQ(originalString, maxLength);
Console.WriteLine("Using LINQ: " + truncatedString_LINQ);

var truncatedString_extensionMethod = originalString.TruncateString(maxLength);
Console.WriteLine("Using Extension method: " + truncatedString_extensionMethod);

var summary = BenchmarkRunner.Run<StringHelperBenchmark>();


Console.ReadKey();