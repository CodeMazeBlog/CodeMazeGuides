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

    [Fact]
    public void GivenStringToChar_WhenInvalidInput_ThenThrowsArgumentException()
    {
        const string inputString = "AB";

        Assert.Throws<FormatException>(() => StringHelper.ConvertSingleCharacterStringToChar(inputString));
    }
}