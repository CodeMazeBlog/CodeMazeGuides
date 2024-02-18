
using CheckIfAStringContainsOnlyLetters;

var text = "hello";

var ret = LinqStringChecker.IsOnlyLetters(text) ? "is" : "is not";
Console.WriteLine($"Linq checker: {text} {ret} composed only by letters");

ret = RegexStringChecker.IsOnlyLetters(text) ? "is" : "is not";
Console.WriteLine($"Regex checker: {text} {ret} composed only by letters");

ret = NativeStringChecker.IsOnlyAsciiLettersByPatternMatching(text) ? "is" : "is not";
Console.WriteLine($"Native Pattern Matching: {text} {ret} composed only by letters");

ret = NativeStringChecker.IsOnlyAsciiLettersBySwitchCase(text) ? "is" : "is not";
Console.WriteLine($"Native switch-case: {text} {ret} composed only by letters");
