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

        var dest = new char[numberOfCharacters];
        for (int i = 0; i < numberOfCharacters; i++)
        {
            dest[i] = inputString[i];
        }

        return dest;
    }

    public ReadOnlySpan<char> UseRemove()
    {
        if (IsInputStringShorter())
            return inputString;

        return inputString.Remove(numberOfCharacters);
    }

    public IEnumerable<char> UseLINQEnumerable()
        => inputString.Take(numberOfCharacters);

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

    public ReadOnlySpan<char> UseToCharArray()
    {
        if (IsInputStringShorter())
            return inputString;

        return inputString.ToCharArray(0, numberOfCharacters);
    }
}