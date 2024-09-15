using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingRegexWithMatches : SearchBase, ISearcher
{
    private readonly Regex _regex;

    public SearchUsingRegexWithMatches(string searchText, bool skipWholeFoundText, bool caseSensitive)
        : base(searchText, skipWholeFoundText, caseSensitive)
    {
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