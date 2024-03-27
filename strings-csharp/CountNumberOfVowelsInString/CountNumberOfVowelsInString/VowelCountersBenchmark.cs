using BenchmarkDotNet.Attributes;
using CountNumberOfVowelsInString;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class VowelCountersBenchmarks
{
    [Benchmark]
    public int CountVowelsUsingForLoop()
    {
        var vowels = "AEIOUaeiou".AsSpan();
        var sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.".AsSpan();

        return VowelCounters.CountVowelsUsingForLoop(sentence, vowels);
    }

    [Benchmark]
    public int CountVowelsUsingForEachLoop()
    {
        var vowels = "AEIOUaeiou".AsSpan();
        var sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.".AsSpan();

        return VowelCounters.CountVowelsUsingForEachLoop(sentence, vowels);
    }

    [Benchmark]
    public int CountVowelsUsingSwitchStatement()
    {
        var sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.".AsSpan();

        return VowelCounters.CountVowelsUsingSwitchStatement(sentence);
    }

    [Benchmark]
    public int CountVowelsUsingRegEx()
    {
        var sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";

        return VowelCounters.CountVowelsUsingRegEx(sentence);
    }

    [Benchmark]
    public int CountVowelsUsingStrReplaceAndLength()
    {
        var sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";

        return VowelCounters.CountVowelsUsingStrReplaceAndLength(sentence);
    }

    [Benchmark]
    public int CountVowelsUsingLinq()
    {
        var vowels = new HashSet<char> { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
        var sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";

        return VowelCounters.CountVowelsUsingLinq(sentence, vowels);
    }
}
