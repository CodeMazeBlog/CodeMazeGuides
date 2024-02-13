namespace GetFirstNCharactersOfAString;
public class FirstNCharactersOfStringGetter(string inputString = "CodeMaze", int numberOfCharacters = 4)
{
    private readonly string _inputString = inputString;
    private readonly int _numberOfCharacters = numberOfCharacters;

    private bool IsInputStringNullOrTooShort()
    {
        return string.IsNullOrEmpty(_inputString) || _inputString.Length < _numberOfCharacters;
    }

    public string? UseRemove()
    {
        if (IsInputStringNullOrTooShort())
            return _inputString;

        return _inputString.Remove(_numberOfCharacters);
    }

    public string? UseLINQ()
    {
        if (IsInputStringNullOrTooShort())
            return _inputString;

        return string.Join("", _inputString.Take(_numberOfCharacters));
    }

    public string? UseRangeOperator()
    {
        if (IsInputStringNullOrTooShort())
            return _inputString;

        return _inputString[.._numberOfCharacters];
    }

    public string? UseAsSpan()
    {
        if (IsInputStringNullOrTooShort())
            return _inputString;

        return _inputString.AsSpan(0, _numberOfCharacters).ToString();
    }

    public string? UseToCharArray()
    {
        if (IsInputStringNullOrTooShort())
            return _inputString;

        return string.Join("", _inputString.ToCharArray(0, _numberOfCharacters));
    }

    public string? UsePadRight()
    {
        return string.IsNullOrEmpty(_inputString)
            ? _inputString
            : _inputString.PadRight(_numberOfCharacters)[.._numberOfCharacters].Trim();
    }
}