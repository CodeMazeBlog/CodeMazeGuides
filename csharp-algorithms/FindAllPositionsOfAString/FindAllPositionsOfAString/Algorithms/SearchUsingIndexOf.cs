using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingIndexOf : SearchBase, ISearcher
{
    public List<int> FindAll(string text, string searchText)
    {
        List<int> positions = [];

        var skipSize = ((SkipWholeFoundText) ? searchText.Length : 1);

        var index = text.IndexOf(searchText, StringComparison);
        while (index != -1)
        {
            positions.Add(index);
            index = text.IndexOf(searchText, index + skipSize, StringComparison);
        }

        return positions;
    }

    private StringComparison StringComparison =>
        CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
}
