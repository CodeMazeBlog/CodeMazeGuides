using EscapingCurlyBracketsInFormatStrings;

var formatExampleResult = FormatStringsEscaping.FormatStringExample();
Console.WriteLine($"Result: {formatExampleResult}\n");

try
{
    FormatStringsEscaping.UnescapedCurlyBrackets();
}
catch (FormatException ex)
{
    Console.WriteLine($"Result: {ex.Message}\n");
}

var curlyBracketsResult = FormatStringsEscaping.CurlyBracketsEscaping();
Console.WriteLine($"Result: {curlyBracketsResult}\n");

var interpolatedResult = FormatStringsEscaping.InterpolatedCurlyBracketsEscaping();
Console.WriteLine($"Result: {interpolatedResult}\n");

var formatSpecifierResult = FormatStringsEscaping.FormatSpecifierInsideCurlyBrackets();
Console.WriteLine($"Result: {formatSpecifierResult}\n");

var interpolatedFormatSpecifierResult = FormatStringsEscaping.InterpolatedFormatSpecifierInsideCurlyBrackets();
Console.WriteLine($"Result: {interpolatedFormatSpecifierResult}\n");

var jsonResult = FormatStringsEscaping.RawStringLiteralJson();
Console.WriteLine($"Result:\n{jsonResult}\n");

var doubleQuotesResult = FormatStringsEscaping.DoubleQuotesEscaping();
Console.WriteLine($"Result: {doubleQuotesResult}\n");

var verbatimQuotesResult = FormatStringsEscaping.DoubleQuotesInVerbatimString();
Console.WriteLine($"Result: {verbatimQuotesResult}\n");

var rawQuotesResult = FormatStringsEscaping.DoubleQuotesInRawStringLiteral();
Console.WriteLine($"Result: {rawQuotesResult}\n");

var backslashResult = FormatStringsEscaping.BackslashEscaping();
Console.WriteLine($"Result: {backslashResult}\n");

var verbatimBackslashResult = FormatStringsEscaping.BackslashInVerbatimString();
Console.WriteLine($"Result: {verbatimBackslashResult}\n");
