namespace FindAllPositionsOfAString;

public class SearchUsingIndexOf : ISearcher
{
    private string _searchValue = string.Empty;

    public void Initialize(string searchValue)
    {
        _searchValue = searchValue;
    }

    public List<int> FindAll(string text)
    {
        List<int> positions = [];

        var index = text.IndexOf(_searchValue);
        while (index != -1)
        {
            positions.Add(index);
            index = text.IndexOf(_searchValue, index + 1);
        }

        return positions;
    }
}
