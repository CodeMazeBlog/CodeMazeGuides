using EscapingCurlyBracketsInFormatStrings;

var formatExampleResult = FormatStringsEscaping.FormatStringExample();
Console.WriteLine($"Result: {formatExampleResult}\n");

var curlyBracketsResult = FormatStringsEscaping.CurlyBracketsEscaping();
Console.WriteLine($"Result: {curlyBracketsResult}\n");

var doubleQuotesResult = FormatStringsEscaping.DoubleQuotesEscaping();
Console.WriteLine($"Result: {doubleQuotesResult}\n");

var backslashResult = FormatStringsEscaping.BackslashEscaping();
Console.WriteLine($"Result: {backslashResult}\n");