namespace CountNumberOfVowelsInStringTests;

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
        var vowelsAsSpan = "AEIOUaeiou".AsSpan();
        var sentenceAsSpan = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.".AsSpan();
        var result = VowelCounters.CountVowelsUsingForLoop(sentenceAsSpan, vowelsAsSpan);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedWithForEachLoop_ThenCorrectCountIsReturned()
    {
        var vowelsAsSpan = "AEIOUaeiou".AsSpan();
        var sentenceAsSpan = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.".AsSpan();
        var result = VowelCounters.CountVowelsUsingForEachLoop(sentenceAsSpan, vowelsAsSpan);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingSwitchStatement_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingSwitchStatement(sentence);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingRegEx_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingRegEx(sentence);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingStrReplaceAndLength_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingStrReplaceAndLength(sentence);

        Assert.Equal(expectedNumOfVowels, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingLINQ_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingLinq(sentence, vowels);

        Assert.Equal(expectedNumOfVowels, result);
    }
}
