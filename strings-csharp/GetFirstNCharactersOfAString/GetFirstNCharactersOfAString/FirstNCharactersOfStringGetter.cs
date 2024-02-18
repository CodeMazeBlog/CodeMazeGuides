using System.Text;

namespace GetFirstNCharactersOfAString;
public class FirstNCharactersOfStringGetter(string inputString = "CodeMaze", int numberOfCharacters = 4)
{
    private readonly string _inputString = inputString;
    private readonly int _numberOfCharacters = numberOfCharacters;

    private bool IsInputStringShorter()
        => _inputString.Length < _numberOfCharacters;

    public ReadOnlySpan<char> UseForLoop()
    {
        if (IsInputStringShorter())
            return _inputString;

        var strBuilder = new StringBuilder();
        for (int i = 0; i < _numberOfCharacters; i++)
        {
            strBuilder.Append(_inputString[i]);
        }

        return strBuilder.ToString();
    }

    public ReadOnlySpan<char> UseRemove()
    {
        if (IsInputStringShorter())
            return _inputString;

        return _inputString.Remove(_numberOfCharacters);
    }

    public ReadOnlySpan<char> UseLINQ()
    {
        if (IsInputStringShorter())
            return _inputString;

        return string.Join("", _inputString.Take(_numberOfCharacters));
    }

    public ReadOnlySpan<char> UseAsSpanWithRangeOperator()
        => IsInputStringShorter()
        ? _inputString
        : _inputString.AsSpan()[.._numberOfCharacters];

    public ReadOnlySpan<char> UseAsSpan()
    {
        if (IsInputStringShorter())
            return _inputString;

        return _inputString.AsSpan(0, _numberOfCharacters);
    }

    public ReadOnlySpan<char> UseReadOnlyMemory()
    {
        if (IsInputStringShorter())
            return _inputString;

        return _inputString.AsMemory()[.._numberOfCharacters].Span;
    }

    public ReadOnlySpan<char> UseToCharArray()
    {
        if (IsInputStringShorter())
            return _inputString;

        return _inputString.ToCharArray(0, _numberOfCharacters);
    }
}