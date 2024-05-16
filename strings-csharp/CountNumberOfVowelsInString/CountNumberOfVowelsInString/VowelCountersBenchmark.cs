using System.Buffers;
using BenchmarkDotNet.Attributes;

namespace CountNumberOfVowelsInString;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class VowelCountersBenchmarks
{
    private const string Sentence =
        "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";

    private const string Vowels = "AEIOUaeiou";

    private static readonly SearchValues<char> _vowelsSearchValues = SearchValues.Create(Vowels);

    private static readonly HashSet<char> _vowelsHash = new(Vowels);

    [Benchmark]
    public int CountVowelsUsingForLoop()
    {
        return VowelCounters.CountVowelsUsingForLoop(Sentence, Vowels);
    }

    [Benchmark]
    public int CountVowelsUsingForEachLoop()
    {
        return VowelCounters.CountVowelsUsingForEachLoop(Sentence, Vowels);
    }

    [Benchmark(Baseline = true)]
    public int CountVowelsUsingSearchValues()
    {
        return VowelCounters.CountVowelsUsingSearchValues(Sentence, _vowelsSearchValues);
    }

    [Benchmark]
    public int CountVowelsUsingSwitchStatement()
    {
        return VowelCounters.CountVowelsUsingSwitchStatement(Sentence);
    }

    [Benchmark]
    public int CountVowelsUsingRegexCount()
    {
        return VowelCounters.CountVowelsUsingRegexCount(Sentence);
    }

    [Benchmark]
    public int CountVowelsUsingRegexReplaceAndLength()
    {
        return VowelCounters.CountVowelsUsingRegexReplaceAndLength(Sentence);
    }

    [Benchmark]
    public int CountVowelsUsingLinq()
    {
        return VowelCounters.CountVowelsUsingLinq(Sentence, _vowelsHash);
    }
}
