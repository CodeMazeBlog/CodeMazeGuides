using BenchmarkDotNet.Attributes;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class VowelCountersBenchmarks
{
    private readonly string sentence;
    private readonly HashSet<char> vowels;

    public VowelCountersBenchmarks()
    {
        vowels = new HashSet<char> { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
        sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";
    }

    [Benchmark]
    public int CountVowelsUsingForLoop()
    {
        return VowelCounters.CountVowelsUsingForLoop(sentence, vowels);
    }

    [Benchmark]
    public int CountVowelsUsingForEachLoop()
    {
        return VowelCounters.CountVowelsUsingForEachLoop(sentence, vowels);
    }

    [Benchmark]
    public int CountVowelsUsingSwitchStatement()
    {
        return VowelCounters.CountVowelsUsingSwitchStatement(sentence);
    }

    [Benchmark]
    public int CountVowelsUsingRegEx()
    {
        return VowelCounters.CountVowelsUsingRegEx(sentence);
    }

    [Benchmark]
    public int CountVowelsUsingStrReplaceAndLength()
    {
        return VowelCounters.CountVowelsUsingStrReplaceAndLength(sentence);
    }

    [Benchmark]
    public int CountVowelsUsingLinq()
    {
        return VowelCounters.CountVowelsUsingLinq(sentence, vowels);
    }
}
