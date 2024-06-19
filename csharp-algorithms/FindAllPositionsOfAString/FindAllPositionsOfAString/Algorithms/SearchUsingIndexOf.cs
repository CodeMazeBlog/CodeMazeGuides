using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingIndexOf : SearchBase, ISearcher
{
    public List<int> FindAll(string text)
    {
        var spanText = text.AsSpan();
        var spanSearch = SearchText.AsSpan();
        List<int> positions = [];

        var offset = 0;
        var index = spanText.IndexOf(spanSearch, StringComparison);
        while (index != -1)
        {
            positions.Add(index + offset);
            offset += index + SkipSize;
            spanText = spanText[(index + SkipSize)..];
            index = spanText.IndexOf(spanSearch, StringComparison);
        }

        return positions;
    }

    private StringComparison StringComparison =>
        CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
}
