using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingRegexWithMatch : SearchBase, ISearcher
{
    public List<int> FindAll(string text)
    {
        List<int> positions = [];
        var startIndex = 0;

        var skipSize = SkipWholeFoundText ? _searchText.Length : 1;
        var regex = new Regex(_searchText, CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);
        while (true)
        {
            Match match = regex.Match(text, startIndex);
            if (!match.Success)
                break;

            positions.Add(match.Index);
            startIndex = match.Index + skipSize;
        }

        return positions;
    }
}