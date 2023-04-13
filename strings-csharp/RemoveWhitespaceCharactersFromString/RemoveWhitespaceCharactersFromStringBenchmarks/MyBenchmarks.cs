using System.Text;
using BenchmarkDotNet.Attributes;
using Bogus;
using Bogus.DataSets;
using RemoveWhitespaceCharactersFromString;

namespace RemoveWhitespaceCharactersFromStringBenchmarks;

[MemoryDiagnoser]
public class MyBenchmarks
{
    private const string CommonSenseFilename = @"./Resources/CommonSense.ThomasPaine.txt";
    private const string ShortTextString = "This is a short\ntext string\twith some whitespace.";
    private const string ShortTextStringNoSpace = "Thisisashorttextstringwithnowhitespace.";

    private static readonly string LoremTextNoSpace = GenerateWordsNoSpace(2000);
    private static readonly string CommonSense = File.ReadAllText(CommonSenseFilename);

    private static string GenerateWordsNoSpace(int wordCount)
    {
        Randomizer.Seed = new Random(42);
        var lorem = new Lorem("fr");
        var sb = new StringBuilder(wordCount * 4);
        for (var i = 0; i < wordCount; ++i) sb.Append(lorem.Word());

        return sb.ToString();
    }

    public IEnumerable<object> StringData()
    {
        yield return ShortTextStringNoSpace;
        yield return ShortTextString;
        yield return LoremTextNoSpace;
        yield return CommonSense;
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithRegexClass(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingRegexClass(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithCachedRegex(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingCachedRegex(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithSourceGenRegex(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingSourceGenRegex(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithLinqConcat(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConcat(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithLinqConstruct(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConstruct(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithReplace(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingReplace(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithSplitJoin(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingSplitJoin(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithStringBuilder(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingStringBuilder(source);
    }

    [Benchmark]
    [ArgumentsSource(nameof(StringData))]
    public string RemoveWhiteSpaceWithArray(string source)
    {
        return RemoveWhitespaceMethods.RemoveWhitespacesUsingArray(source);
    }
}