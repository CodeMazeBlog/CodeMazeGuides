using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingRegexWithMatch : SearchBase, ISearcher
{
    private Regex _regex = null!;

    public new void Initialize(string searchText)
    {
        base.Initialize(searchText);

        _regex = new Regex(SearchText, StringComparison);
    }

    public List<int> FindAll(string text)
    {
        List<int> positions = [];

        Match match = _regex.Match(text);
        while (match.Success)
        {
            positions.Add(match.Index);
            match = _regex.Match(text, match.Index + SkipSize);
        }

        return positions;
    }

    private RegexOptions StringComparison =>
        CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
}