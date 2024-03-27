namespace CountNumberOfVowelsInStringTests;

public class VowelCountersTests
{
    private const string Sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";
    private const string Vowels = "AEIOUaeiou";
    private const int ExpectedNumOfVowels = 46;

    private static readonly string _noVowels = new('b', 100);
    private static readonly HashSet<char> _vowelsHash = new(Vowels);

    [Fact]
    public void WhenVowelsAreCountedWithSearchValues_ThenCorrectCountIsReturned()
    {
        var vowelsSearchValues = SearchValues.Create(Vowels);
        var result = VowelCounters.CountVowelsUsingSearchValues(Sentence.AsSpan(), vowelsSearchValues);

        Assert.Equal(ExpectedNumOfVowels, result);
    }

    [Fact]
    public void GivenStringWithNoVowels_WhenVowelsAreCountedWithSearchValues_ThenCorrectCountIsReturned()
    {
        var searchValues = SearchValues.Create(Vowels);
        var result = VowelCounters.CountVowelsUsingSearchValues(_noVowels.AsSpan(), searchValues);

        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenVowelsAreCountedWithForLoop_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingForLoop(Sentence.AsSpan(), Vowels.AsSpan());

        Assert.Equal(ExpectedNumOfVowels, result);
    }

    [Fact]
    public void GivenStringWithNoVowels_WhenVowelsAreCountedWithForLoop_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingForLoop(_noVowels.AsSpan(), Vowels.AsSpan());

        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenVowelsAreCountedWithForEachLoop_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingForEachLoop(Sentence.AsSpan(), Vowels.AsSpan());

        Assert.Equal(ExpectedNumOfVowels, result);
    }

    [Fact]
    public void GivenStringWithNoVowels_WhenVowelsAreCountedWithForEachLoop_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingForEachLoop(_noVowels.AsSpan(), Vowels.AsSpan());

        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingSwitchStatement_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingSwitchStatement(Sentence.AsSpan());

        Assert.Equal(ExpectedNumOfVowels, result);
    }
    
    [Fact]
    public void GivenStringWithNoVowels_WhenVowelsAreCountedUsingSwitchStatement_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingSwitchStatement(_noVowels.AsSpan());

        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingRegEx_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingRegEx(Sentence);

        Assert.Equal(ExpectedNumOfVowels, result);
    }

    [Fact]
    public void GivenStringWithNoVowels_WhenVowelsAreCountedUsingRegEx_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingRegEx(_noVowels);

        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingRegexReplaceAndLength_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingRegexReplaceAndLength(Sentence);

        Assert.Equal(ExpectedNumOfVowels, result);
    }

    [Fact]
    public void GivenStringWithNoVowels_WhenVowelsAreCountedUsingRegexReplaceAndLength_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingRegexReplaceAndLength(_noVowels);

        Assert.Equal(0, result);
    }

    [Fact]
    public void WhenVowelsAreCountedUsingLINQ_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingLinq(Sentence, _vowelsHash);

        Assert.Equal(ExpectedNumOfVowels, result);
    }

    [Fact]
    public void GivenStringWithNoVowels_WhenVowelsAreCountedUsingLINQ_ThenCorrectCountIsReturned()
    {
        var result = VowelCounters.CountVowelsUsingLinq(_noVowels, _vowelsHash);

        Assert.Equal(0, result);
    }
}
