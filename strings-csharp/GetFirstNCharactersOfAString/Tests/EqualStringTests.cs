using Xunit;

namespace Tests;

public class EqualStringTests
{
    private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
    private readonly char[] _expectedChars = ['C', 'o', 'd', 'e'];

    public EqualStringTests()
    {
        _firstNCharactersOfStringGetter = new FirstNCharactersOfStringGetter("Code", 4);
    }

    [Fact]
    public void WhenUseForLoopIsCalledWithEqualString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseForLoop();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseRemoveIsCalledWithEqualString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseRemove();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseLINQEnumerableIsCalledWithEqualString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseLINQEnumerable();

        Assert.Equal(_expectedChars.Length, result.Count());
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanIsCalledWithEqualString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpan();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanWithRangeOperatorIsCalledWithEqualString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseToCharArrayIsCalledWithEqualString_ThenReturnsTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseToCharArray();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }
}