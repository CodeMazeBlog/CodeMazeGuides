using BenchmarkDotNet.Attributes;
using Bogus.DataSets;
using RemoveWhitespaceCharactersFromString;

namespace RemoveWhitespaceCharactersFromStringBenchmarks;

[MemoryDiagnoser]
[MinIterationTime(500)]
public class TrimWhitespaceBenchmarks
{
    private static readonly string NewLines = new('\n', 5);
    private static readonly string Tabs = new('\t', 5);
    private static readonly string Spaces = new(' ', 5);
    private static readonly string NonBreakingSpaces = new('\u00A0', 5);
    private static readonly Lorem LoremGen = new();

    private static readonly string SentenceNoLeadingOrTrailingWhitespace = LoremGen.Sentence(75).Trim();

    private static readonly string SentenceWithLeadingAndTrailingWhitespace =
        $"{Tabs}{NewLines}{NonBreakingSpaces}{Spaces}{SentenceNoLeadingOrTrailingWhitespace}{Tabs}{NewLines}{NonBreakingSpaces}{Spaces}";

    private static readonly string LongRandomString = LoremGen.Paragraphs(25).Trim();

    private static readonly string LongRandomStringWithLeadingAndTrailingWhitespace =
        $"{NewLines}{Tabs}{NonBreakingSpaces}{Spaces}{LongRandomString}{Spaces}{NonBreakingSpaces}{NewLines}{Tabs}";

    public IEnumerable<object> StringData()
    {
        yield return SentenceNoLeadingOrTrailingWhitespace;
        yield return SentenceWithLeadingAndTrailingWhitespace;
        yield return LongRandomString;
        yield return LongRandomStringWithLeadingAndTrailingWhitespace;
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingStringTrim(string source)
    {
        return RemoveWhitespaceMethods.TrimWhitespacesUsingStringTrim(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingSourceGenRegex(string source)
    {
        return RemoveWhitespaceMethods.TrimWhitespacesUsingSourceGenRegex(source);
    }
}