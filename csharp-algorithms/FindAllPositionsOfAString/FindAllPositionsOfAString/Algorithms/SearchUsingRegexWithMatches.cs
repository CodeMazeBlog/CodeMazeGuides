using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingRegexWithMatches : SearchBase, ISearcher
{
    public List<int> FindAll(string text, string searchText)
    {
        if (!SkipWholeFoundText)
            throw new NotSupportedException("For SearchUsingRegexWithMatches SkipWholeFoundText should be set to true");

        return new Regex(searchText, CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase)
            .Matches(text)
            .Select(match => match.Index)
            .ToList();
    }
}

