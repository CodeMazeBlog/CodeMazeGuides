using StringTruncationInCSharp;

StringHelper stringHelper = new StringHelper();
var originalString = "This is a long string.";
var maxLength = 10;

var truncatedString_substring = stringHelper.TruncateStringUsingSubstring(originalString, maxLength);
Console.WriteLine("Using Substring method: " + truncatedString_substring);

var truncatedString_stringInterpolation = stringHelper.TruncateStringUsingStringInterpolation(originalString, maxLength);
Console.WriteLine("Using String Interpolation: " + truncatedString_stringInterpolation);

var truncatedString_forLoop = stringHelper.TruncateStringUsingForLoop(originalString, maxLength);
Console.WriteLine("Using For Loop: " + truncatedString_forLoop);

var truncatedString_stringBuilder = stringHelper.TruncateStringUsingStringBuilder(originalString, maxLength);
Console.WriteLine("Using StringBuilder: " + truncatedString_stringBuilder);

var truncatedString_regularExpressions = stringHelper.TruncateStringUsingRegularExpressions(originalString, maxLength);
Console.WriteLine("Using Regular Expressions: " + truncatedString_regularExpressions);

var truncatedString_remove = stringHelper.TruncateStringUsingRemove(originalString, maxLength);
Console.WriteLine("Using Remove method: " + truncatedString_remove);

var truncatedString_LINQ = stringHelper.TruncateStringUsingLINQ(originalString, maxLength);
Console.WriteLine("Using LINQ: " + truncatedString_LINQ);


Console.ReadKey();