namespace Tests;

public class ShorterStringTests
{
    private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
    private readonly char[] _expectedChars = ['C', 'o', 'd'];

    public ShorterStringTests()
    {
        _firstNCharactersOfStringGetter = new FirstNCharactersOfStringGetter("Cod", 8);
    }

    [Fact]
    public void WhenUseForLoopIsCalledWithShorterString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseForLoop();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseRemoveIsCalledWithShorterString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseRemove();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseLINQEnumerableIsCalledWithShorterString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseLINQEnumerable();

        Assert.Equal(_expectedChars.Length, result.Count());
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanIsCalledWithShorterString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpan();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanWithRangeOperatorIsCalledWithShorterString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseToCharArrayIsCalledWithShorterString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseToCharArray();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }
}