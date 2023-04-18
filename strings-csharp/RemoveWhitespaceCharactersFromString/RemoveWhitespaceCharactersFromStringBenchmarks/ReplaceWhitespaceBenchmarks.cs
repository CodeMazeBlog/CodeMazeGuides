using BenchmarkDotNet.Attributes;
using Bogus.DataSets;
using RemoveWhitespaceCharactersFromString;

namespace RemoveWhitespaceCharactersFromStringBenchmarks;

[MemoryDiagnoser]
[MinIterationTime(500)]
public class ReplaceWhitespaceBenchmarks
{
    private const string CommonSenseFilename = @"./Resources/CommonSense.ThomasPaine.txt";
    private static readonly string CommonSense = File.ReadAllText(CommonSenseFilename);

    private static readonly Lorem LoremGen = new();

    private static readonly string ShortTextString = LoremGen.Sentence(10);

    private static readonly string ShortTextStringNoSpace =
        RemoveWhitespaceMethods.SourceGenRemoveWhitespaceRegex().Replace(ShortTextString, string.Empty);

    private static readonly string LoremTextWithSpace = LoremGen.Paragraphs(50, "\r\n\u00A0\t");

    private static readonly string LoremTextNoSpace =
        RemoveWhitespaceMethods.SourceGenRemoveWhitespaceRegex().Replace(LoremTextWithSpace, string.Empty);

    public IEnumerable<object> StringData()
    {
        yield return ShortTextStringNoSpace;
        yield return ShortTextString;
        yield return LoremTextNoSpace;
        yield return LoremTextWithSpace;
        yield return CommonSense;
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingStaticRegexClass(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingStaticRegexClass(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingCachedRegex(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingCachedRegex(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingSourceGenRegex(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingSourceGenRegex(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingLinqWithConcat(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConcat(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingLinqWithConstruct(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConstruct(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingReplace(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingReplace(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingSplitJoin(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingSplitJoin(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingStringBuilder(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingStringBuilder(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string UsingArray(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingArray(source);
    }
}