namespace FindAllPositionsOfAString;

public class SearchUsingBruteForceAlgorithm : ISearcher
{
    private string _searchValue = string.Empty;

    public void Initialize(string searchValue)
    {
        _searchValue = searchValue;
    }

    public List<int> FindAll(string text)
    {
        ReadOnlySpan<char> searchValueSpan = _searchValue.AsSpan();
        ReadOnlySpan<char> textSpan = text.AsSpan();

        List<int> positions = [];
        var textLength = textSpan.Length;
        var searchLen = searchValueSpan.Length;

        for (var textPosition = 0; textPosition <= textLength - searchLen; textPosition++)
        {
            int searchPosition;

            for (searchPosition = 0; searchPosition < searchLen; searchPosition++)
            {
                if (textSpan[textPosition + searchPosition] != searchValueSpan[searchPosition])
                    break;
            }

            if (searchPosition == searchLen)
                positions.Add(textPosition);
        }

        return positions;
    }
}
