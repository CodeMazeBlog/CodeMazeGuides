using Deprecation.StringUtils;

const string originalString = "Hello, World!";
var reversed = StringUtils.ReverseString(originalString); // Deprecated method
var reversedV2 = StringUtils.ReverseStringV2(originalString); // Recommended method

Console.WriteLine("Reversed (Deprecated Method): " + reversed);
Console.WriteLine("Reversed V2 (Recommended Method): " + reversedV2);

