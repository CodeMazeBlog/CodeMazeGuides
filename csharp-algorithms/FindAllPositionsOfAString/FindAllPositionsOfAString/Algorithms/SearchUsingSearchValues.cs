using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Buffers;
using System.Linq;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingSearchValues : SearchBase, ISearcher
{
    private SearchValues<string> _searchValues = null!;

    public new void Initialize(string searchText)
    {
        base.Initialize(searchText);

        _searchValues = SearchValues.Create([SearchText], StringComparison);
    }

    public List<int> FindAll(string text)
    {
        var spanText = text.AsSpan();
        List<int> positions = [];

        var offset = 0;
        var index = spanText.IndexOfAny(_searchValues);
        while (index != -1)
        {
            positions.Add(index + offset);
            offset += index + SkipSize;
            spanText = spanText[(index + SkipSize)..];
            index = spanText.IndexOfAny(_searchValues);
        }

        return positions;
    }

    private StringComparison StringComparison =>
        CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
}
