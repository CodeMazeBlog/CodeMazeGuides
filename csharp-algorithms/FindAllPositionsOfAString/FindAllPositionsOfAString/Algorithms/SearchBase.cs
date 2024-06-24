namespace FindAllPositionsOfAString.Algorithms;

public abstract class SearchBase
{
    protected string SearchText { get; private set; } = string.Empty;
    protected int SearchTextLength { get; private set; } = 0;
    protected int SkipSize { get; private set; } = 1;

    public bool CaseSensitive { get; private set; }
    public bool SkipWholeFoundText { get; private set; }

    protected SearchBase(string searchText, bool skipWholeFoundText, bool caseSensitive)
    {
        SearchText = searchText;
        SkipWholeFoundText = skipWholeFoundText;
        CaseSensitive = caseSensitive;
        SearchTextLength = SearchText.Length;
        SkipSize = SkipWholeFoundText ? SearchText.Length : 1;
    }

    protected static bool AreEqualCharactersSensitive(char a, char b)
        => a == b;

    protected static bool AreEqualCharactersInsensitive(char a, char b)
        => char.ToUpperInvariant(a) == char.ToUpperInvariant(b);
}
