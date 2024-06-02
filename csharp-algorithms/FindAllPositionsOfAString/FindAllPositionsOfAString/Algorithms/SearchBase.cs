namespace FindAllPositionsOfAString.Algorithms;

public class SearchBase
{
    protected string _searchText = string.Empty;

    public bool CaseSensitive { get; set; } = true;
    public bool SkipWholeFoundText { get; set; } = false;

    public void Initialize(string searchText)
    {
        _searchText = searchText;
    }

    protected bool AreEqualCharacters(char a, char b)
    {
        return CaseSensitive ? a == b : char.ToLowerInvariant(a) == char.ToLowerInvariant(b);
    }
}
