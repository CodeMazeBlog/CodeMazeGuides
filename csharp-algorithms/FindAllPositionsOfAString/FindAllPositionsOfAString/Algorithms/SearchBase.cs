namespace FindAllPositionsOfAString.Algorithms;

public class SearchBase
{
    protected string SearchText { get; private set; } = string.Empty;
    protected int SearchTextLength { get; private set; } = 0;
    protected int SkipSize { get; private set; } = 1;

    public bool CaseSensitive { get; set; } = true;
    public bool SkipWholeFoundText { get; set; } = false;

    public void Initialize(string searchText)
    { 
        SearchText = searchText; 
        SearchTextLength = SearchText.Length;
        SkipSize = SkipWholeFoundText ? SearchText.Length : 1;
    }

    protected static bool AreEqualCharactersSensitive(char a, char b)
        => a == b;

    protected static bool AreEqualCharactersInsensitive(char a, char b)
        => char.ToUpperInvariant(a) == char.ToUpperInvariant(b);
}
