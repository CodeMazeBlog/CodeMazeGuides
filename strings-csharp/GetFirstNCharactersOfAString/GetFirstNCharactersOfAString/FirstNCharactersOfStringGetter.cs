using System.Text;

namespace GetFirstNCharactersOfAString;

public class FirstNCharactersOfStringGetter(string inputString = "CodeMaze", int numberOfCharacters = 4)
{
    private bool IsInputStringShorter()
        => inputString.Length < numberOfCharacters;

    public ReadOnlySpan<char> UseForLoop()
    {
        if (IsInputStringShorter())
            return inputString;

        var strBuilder = new StringBuilder(numberOfCharacters);
        for (int i = 0; i < numberOfCharacters; i++)
        {
            strBuilder.Append(inputString[i]);
        }

        return strBuilder.ToString();
    }

    public ReadOnlySpan<char> UseRemove()
    {
        if (IsInputStringShorter())
            return inputString;

        return inputString.Remove(numberOfCharacters);
    }

    public ReadOnlySpan<char> UseLINQ()
        => string.Join("", inputString.Take(numberOfCharacters));

    public ReadOnlySpan<char> UseAsSpanWithRangeOperator()
        => IsInputStringShorter()
        ? inputString
        : inputString.AsSpan()[..numberOfCharacters];

    public ReadOnlySpan<char> UseAsSpan()
    {
        if (IsInputStringShorter())
            return inputString;

        return inputString.AsSpan(0, numberOfCharacters);
    }

    public ReadOnlySpan<char> UseAsMemory()
    {
        if (IsInputStringShorter())
            return inputString;

        return inputString.AsMemory()[..numberOfCharacters].Span;
    }

    public ReadOnlySpan<char> UseToCharArray()
    {
        if (IsInputStringShorter())
            return inputString;

        return inputString.ToCharArray(0, numberOfCharacters);
    }
}