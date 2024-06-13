namespace FindAllPositionsOfAString.Algorithms;

public class SearchBase
{
    public bool CaseSensitive { get; set; } = true;
    public bool SkipWholeFoundText { get; set; } = false;

    protected bool AreEqualCharactersSensitive(char a, char b)
        => a == b;

    protected bool AreEqualCharactersInsensitive(char a, char b)
        => char.ToLowerInvariant(a) == char.ToLowerInvariant(b);
}
