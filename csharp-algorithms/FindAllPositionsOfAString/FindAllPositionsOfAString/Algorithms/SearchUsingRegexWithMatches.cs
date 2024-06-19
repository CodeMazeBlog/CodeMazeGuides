using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingRegexWithMatches : SearchBase, ISearcher
{
    private Regex _regex = null!;

    public new void Initialize(string searchText)
    {
        base.Initialize(searchText);

        _regex = new Regex(SearchText, CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);
    }

    public List<int> FindAll(string text)
    {
        if (!SkipWholeFoundText)
            throw new NotSupportedException("For SearchUsingRegexWithMatches SkipWholeFoundText should be set to true");

        return _regex
            .Matches(text)
            .Select(match => match.Index)
            .ToList();
    }
}

