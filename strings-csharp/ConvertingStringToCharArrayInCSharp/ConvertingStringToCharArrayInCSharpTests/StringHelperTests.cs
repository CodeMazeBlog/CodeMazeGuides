namespace ConvertingStringToCharArrayInCSharpTests;

public class StringHelperTests
{
    private const string InputString = "Hello, World!";

    [Fact]
    public void GivenStringToCharArray_WhenValidInput_ThenReturnsCharArray()
    {
        char[] result = StringHelper.ConvertStringToCharArray(InputString);

        Assert.Equal(InputString.ToCharArray(), result);
    }

    [Fact]
    public void GivenStringToCharArrayUsingReadOnlySpan_WhenValidInput_ThenReturnsReadOnlySpan()
    {
        ReadOnlySpan<char> result = StringHelper.ConvertStringToCharArrayUsingReadOnlySpan(InputString);

        Assert.True(InputString.AsSpan().SequenceEqual(result));
    }

    [Fact]
    public void GivenStringToChar_WhenValidInput_ThenReturnsChar()
    {
        const string inputString = "A";

        char result = StringHelper.ConvertSingleCharacterStringToChar(inputString);

        Assert.Equal('A', result);
    }

    [Fact]
    public void GivenStringArrayToCharArray_WhenValidInput_ThenReturnsCharArray()
    {
        string[] stringArray = [InputString[..7], InputString[7..]];

        char[] resultLoop = StringHelper.ConvertStringArrayToCharArrayUsingLoop(stringArray);
        char[] resultLinq = StringHelper.ConvertStringArrayToCharArrayUsingLinq(stringArray);

        Assert.Equal(InputString.ToCharArray(), resultLoop);
        Assert.Equal(InputString.ToCharArray(), resultLinq);
    }

    [Theory]
    [InlineData("AB")]
    [InlineData("")]
    public void GivenStringToChar_WhenLengthIsNotOne_ThenThrowsFormatException(string inputString)
    {
        Assert.Throws<FormatException>(() => StringHelper.ConvertSingleCharacterStringToChar(inputString));
    }

    [Fact]
    public void GivenStringToChar_WhenNull_ThenThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => StringHelper.ConvertSingleCharacterStringToChar(null!));
    }

    [Fact]
    public void GivenCharacterAtIndex_WhenIndexInRange_ThenReturnsThatChar()
    {
        Assert.Equal('H', StringHelper.GetCharacterAtIndex(InputString, 0));
        Assert.Equal('W', StringHelper.GetCharacterAtIndex(InputString, 7));
    }

    [Fact]
    public void GivenCharacterAtIndex_WhenStringIsEmpty_ThenThrowsIndexOutOfRangeException()
    {
        Assert.Throws<IndexOutOfRangeException>(() => StringHelper.GetCharacterAtIndex(string.Empty, 0));
    }

    [Theory]
    [InlineData("A", true)]
    [InlineData("AB", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void GivenTryConvert_WhenCalled_ThenReportsSuccessWithoutThrowing(string? inputString, bool expectedSuccess)
    {
        bool success = StringHelper.TryConvertSingleCharacterStringToChar(inputString, out char result);

        Assert.Equal(expectedSuccess, success);
        if (success)
            Assert.Equal(inputString![0], result);
    }

    [Fact]
    public void GivenEmoji_WhenConverted_ThenTwoCharsAndParseFails()
    {
        const string thumbsUp = "\U0001F44D";

        Assert.Equal(2, thumbsUp.Length);
        Assert.True(char.IsHighSurrogate(StringHelper.GetCharacterAtIndex(thumbsUp, 0)));
        Assert.False(StringHelper.TryConvertSingleCharacterStringToChar(thumbsUp, out _));
        Assert.Equal(0x1F44D, System.Text.Rune.GetRuneAt(thumbsUp, 0).Value);
    }
}