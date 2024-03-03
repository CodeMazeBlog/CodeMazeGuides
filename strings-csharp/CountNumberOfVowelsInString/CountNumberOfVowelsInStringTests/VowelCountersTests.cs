namespace CountNumberOfVowelsInStringTests;
using System.Collections.Generic;

public class VowelCountersTests
{
    private readonly string sentence;
    private readonly HashSet<char> vowels;
    private readonly int expectedNumOfVowels;

    public VowelCountersTests()
    {
        vowels = new HashSet<char> { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
        sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";
        expectedNumOfVowels = 46;
    }

    [Fact]
    public void WhenVowelsAreCountedWithForLoop_ThenCorrectCountIsReturned()
    {
        
        int result = VowelCounters.CountVowelsWithForLoop(sentence, vowels);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedWithForEachLoop_ThenCorrectCountIsReturned()
    {
        int result = VowelCounters.CountVowelsWithForEachLoop(sentence, vowels);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingSwitchStatement_ThenCorrectCountIsReturned()
    {
        int result = VowelCounters.CountVowelsUsingSwitchStatement(sentence);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingRegEx_ThenCorrectCountIsReturned()
    {
        int result = VowelCounters.CountVowelsUsingRegEx(sentence);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingStrReplaceAndLength_ThenCorrectCountIsReturned()
    {
        int result = VowelCounters.CountVowelsUsingStrReplaceAndLength(sentence);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingLINQ_ThenCorrectCountIsReturned()
    {
        int result = VowelCounters.CountVowelsUsingLinq(sentence, vowels);

        Assert.Equal(expectedNumOfVowels, result);
    }
}
