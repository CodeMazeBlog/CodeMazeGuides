namespace GetFirstNCharactersOfAString;
public class FirstNCharactersOfStringGetter(string inputString = "CodeMaze", int numberOfCharacters = 4)
{
    private readonly string _inputString = inputString;
    private readonly int _numberOfCharacters = numberOfCharacters;

    private bool IsInputStringNullOrEmptyOrShorter()
        => string.IsNullOrEmpty(_inputString) || _inputString.Length < _numberOfCharacters;

    public string? UseRemove()
    {
        if (IsInputStringNullOrEmptyOrShorter())
            return _inputString;

        return _inputString.Remove(_numberOfCharacters);
    }

    public string? UseLINQ()
    {
        if (IsInputStringNullOrEmptyOrShorter())
            return _inputString;

        return string.Join("", _inputString.Take(_numberOfCharacters));
    }

    public string? UseRangeOperator()
    {
        if (IsInputStringNullOrEmptyOrShorter())
            return _inputString;

        return _inputString[.._numberOfCharacters];
    }

    public string? UseAsSpan()
    {
        if (IsInputStringNullOrEmptyOrShorter())
            return _inputString;

        return _inputString.AsSpan(0, _numberOfCharacters).ToString();
    }

    public string? UseToCharArray()
    {
        if (IsInputStringNullOrEmptyOrShorter())
            return _inputString;

        return string.Join("", _inputString.ToCharArray(0, _numberOfCharacters));
    }

    public string? UsePadRight()
        => string.IsNullOrEmpty(_inputString)
        ? _inputString
        : _inputString.PadRight(_numberOfCharacters)[.._numberOfCharacters].Trim();
}