namespace Tests;

public class SubstringAndRangeTests
{
    [Theory]
    [InlineData("Code", 4, "Code")]
    [InlineData("CodeMazeGuides", 8, "CodeMaze")]
    [InlineData("Cod", 8, "Cod")]
    public void WhenUseSubstringIsCalled_ThenReturnsTheFirstNCharacters(
        string input, int count, string expected)
    {
        var result = new FirstNCharactersOfStringGetter(input, count).UseSubstring();

        Assert.Equal(expected, result.ToString());
    }

    [Theory]
    [InlineData("Code", 4, "Code")]
    [InlineData("CodeMazeGuides", 8, "CodeMaze")]
    [InlineData("Cod", 8, "Cod")]
    public void WhenUseRangeOperatorIsCalled_ThenReturnsTheFirstNCharacters(
        string input, int count, string expected)
    {
        var result = new FirstNCharactersOfStringGetter(input, count).UseRangeOperator();

        Assert.Equal(expected, result.ToString());
    }

    [Theory]
    [InlineData("Code", 4, "Code")]
    [InlineData("CodeMazeGuides", 8, "CodeMaze")]
    [InlineData("Cod", 8, "Cod")]
    [InlineData("", 4, "")]
    public void WhenUseRangeWithMathMinIsCalled_ThenReturnsAtMostNCharacters(
        string input, int count, string expected)
    {
        var result = new FirstNCharactersOfStringGetter(input, count).UseRangeWithMathMin();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenGetFirstCharacterIsCalled_ThenReturnsTheFirstCharacter()
    {
        var result = new FirstNCharactersOfStringGetter("CodeMaze").GetFirstCharacter();

        Assert.Equal('C', result);
    }

    [Fact]
    public void WhenGetFirstCharacterIsCalledOnAnEmptyString_ThenThrows()
    {
        var getter = new FirstNCharactersOfStringGetter("");

        Assert.Throws<IndexOutOfRangeException>(() => getter.GetFirstCharacter());
    }
}
