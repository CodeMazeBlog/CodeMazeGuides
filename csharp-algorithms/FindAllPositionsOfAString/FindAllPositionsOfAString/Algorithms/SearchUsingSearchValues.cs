using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Buffers;
using System.Linq;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingSearchValues : SearchBase, ISearcher
{
    public List<int> FindAll(string text, string searchText)
    {
        var spanText = text.AsSpan();
        var search = SearchValues.Create([searchText], StringComparison);
        List<int> positions = [];

        var skipSize = ((SkipWholeFoundText) ? searchText.Length : 1);

        var offset = 0;
        var index = spanText.IndexOfAny(search);
        while (index != -1)
        {
            positions.Add(index + offset);
            offset += index + skipSize;
            spanText = spanText[(index + skipSize)..];
            index = spanText.IndexOfAny(search);
        }

        return positions;
    }

    private StringComparison StringComparison =>
        CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
}
