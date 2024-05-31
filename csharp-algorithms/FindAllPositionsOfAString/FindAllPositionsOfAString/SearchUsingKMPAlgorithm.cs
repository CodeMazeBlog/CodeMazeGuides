namespace FindAllPositionsOfAString;

public class SearchUsingKMPAlgorithm : ISearcher
{
    private int[] prefix = [];
    private string _searchValue = string.Empty;

    public void Initialize(string searchValue)
    {
        _searchValue = searchValue;
        ComputePrefix();
    }

    private void ComputePrefix()
    {
        ReadOnlySpan<char> searchValueSpan = _searchValue.AsSpan();

        prefix = new int[searchValueSpan.Length];

        var len = 0;
        var positions = 1;
        while (positions < searchValueSpan.Length)
        {
            if (searchValueSpan[positions] == searchValueSpan[len])
            {
                len++;
                prefix[positions] = len;
                positions++;
            }
            else
            {
                if (len != 0)
                {
                    len = prefix[len - 1];
                }
                else
                {
                    prefix[positions] = len;
                    positions++;
                }
            }
        }
    }

    public List<int> FindAll(string text)
    {
        ReadOnlySpan<char> searchValueSpan = _searchValue.AsSpan();
        ReadOnlySpan<char> textSpan = text.AsSpan();

        List<int> positions = [];

        var textLength = textSpan.Length;
        var searchLen = searchValueSpan.Length;

        var textPosition = 0;
        var searchPosition = 0;

        while (textPosition < textSpan.Length)
        {
            if (searchValueSpan[searchPosition] == textSpan[textPosition])
            {
                textPosition++;
                searchPosition++;
            }

            if (searchPosition == searchLen)
            {
                positions.Add(textPosition - searchPosition);
                searchPosition = prefix[searchPosition - 1];
            }
            else if (textPosition < textLength && searchValueSpan[searchPosition] != textSpan[textPosition])
            {
                if (searchPosition != 0)
                    searchPosition = prefix[searchPosition - 1];
                else
                    textPosition++;
            }
        }

        return positions;
    }
}
