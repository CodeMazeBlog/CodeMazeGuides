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
    public void WhenUseForLoopIsCalledWithLongerString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseForLoop();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseRemoveIsCalledWithLongerString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseRemove();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseLINQEnumerableIsCalledWithLongerString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseLINQEnumerable();

        Assert.Equal(_expectedChars.Length, result.Count());
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanIsCalledWithLongerString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpan();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseAsSpanWithRangeOperatorIsCalledWithLongerString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }

    [Fact]
    public void WhenUseToCharArrayIsCalledWithLongerString_ThenReturnsTheFirstEightCharactersOfTheInputString()
    {
        var result = _firstNCharactersOfStringGetter.UseToCharArray();

        Assert.Equal(_expectedChars.Length, result.Length);
        Assert.Equal(_expectedChars, result.ToArray());
    }
}