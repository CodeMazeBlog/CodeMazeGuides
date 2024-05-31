namespace FindAllPositionsOfAString;

public class SearchUsingRegex : ISearcher
{
    private string _searchValue = string.Empty;

    public void Initialize(string searchValue)
    {
        _searchValue = searchValue;
    }

    public List<int> FindAll(string text)
    {
        List<int> positions = [];
        var currentIndex = 0;

        var regex = new System.Text.RegularExpressions.Regex(_searchValue);
        while (true)
        {
            System.Text.RegularExpressions.Match match = regex.Match(text);
            if (!match.Success)
                break;

            currentIndex += match.Index;
            positions.Add(currentIndex++);
            text = text.Substring(match.Index + 1);
        }

        return positions;
    }
}
