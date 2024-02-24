namespace Tests;

public class LongerStringTests
{
    private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;
    private readonly char[] _expectedChars = ['C', 'o', 'd', 'e', 'M', 'a', 'z', 'e'];

    public LongerStringTests()
    {
        _firstNCharactersOfStringGetter = new FirstNCharactersOfStringGetter("CodeMazeGuides", 8);
    }

    [Fact]
    public void WhenUseForLoopIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseForLoop();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseRemoveIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseRemove();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseLINQEnumerableIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseLINQEnumerable();

        Assert.Equal(_expectedChars.Length, result.Count());
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpan();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanWithRangeOperatorIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsMemoryIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsMemory();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseToCharArrayIsCalledWithEqualString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseToCharArray();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }
}