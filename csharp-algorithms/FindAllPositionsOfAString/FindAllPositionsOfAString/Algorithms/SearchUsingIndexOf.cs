using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingIndexOf : SearchBase, ISearcher
{
    public List<int> FindAll(string text)
    {
        List<int> positions = [];

        var skipSize = ((SkipWholeFoundText) ? _searchText.Length : 1);

        var index = text.IndexOf(_searchText, GetStringComparison);
        while (index != -1)
        {
            positions.Add(index);
            index = text.IndexOf(_searchText, index + skipSize, GetStringComparison);
        }

        return positions;
    }

    private StringComparison GetStringComparison => 
        CaseSensitive 
            ? StringComparison.Ordinal 
            : StringComparison.OrdinalIgnoreCase;
}
