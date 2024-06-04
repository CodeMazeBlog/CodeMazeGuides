using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingRegexWithMatch : SearchBase, ISearcher
{
    public List<int> FindAll(string text, string searchText)
    {
        List<int> positions = [];

        var skipSize = SkipWholeFoundText ? searchText.Length : 1;

        var regex = new Regex(searchText, StringComparison);

        Match match = regex.Match(text);
        while (match.Success)
        {
            positions.Add(match.Index);
            match = regex.Match(text, match.Index + skipSize);
        }

        return positions;
    }

    private RegexOptions StringComparison =>
        CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
}