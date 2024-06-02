using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Text.RegularExpressions;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingRegexWithMatches : SearchBase, ISearcher
{
    public List<int> FindAll(string text)
    {
        if (!SkipWholeFoundText)
            throw new NotSupportedException("For SearchUsingRegexWithMatches SkipWholeFoundText should be set to true");

        List<int> positions = [];
        var regex = new Regex(_searchText, CaseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);
        foreach (Match match in regex.Matches(text))
        {
            positions.Add(match.Index);
        }

        return positions;
    }
}

