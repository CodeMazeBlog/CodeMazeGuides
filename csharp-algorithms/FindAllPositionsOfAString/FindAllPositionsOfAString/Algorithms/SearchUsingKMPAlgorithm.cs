using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingKMPAlgorithm : SearchBase, ISearcher
{
    private int[] prefix = [];

    public new void Initialize(string searchValue)
    {
        base.Initialize(searchValue);
        ComputePrefix();
    }

    private void ComputePrefix()
    {
        ReadOnlySpan<char> searchValueSpan = _searchText.AsSpan();

        prefix = new int[searchValueSpan.Length];

        var len = 0;
        var positions = 1;
        while (positions < searchValueSpan.Length)
        {
            if (AreEqualCharacters(searchValueSpan[positions], searchValueSpan[len]))
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
        if (SkipWholeFoundText)
            throw new NotSupportedException("SkipWholeFoundText is not supported for KMP algorithm.");

        ReadOnlySpan<char> searchValueSpan = _searchText.AsSpan();
        ReadOnlySpan<char> textSpan = text.AsSpan();

        List<int> positions = [];

        var textLength = textSpan.Length;
        var searchLen = searchValueSpan.Length;

        var textPosition = 0;
        var searchPosition = 0;

        while (textPosition < textSpan.Length)
        {
            if (AreEqualCharacters(searchValueSpan[searchPosition], textSpan[textPosition]))
            {
                textPosition++;
                searchPosition++;
            }

            if (searchPosition == searchLen)
            {
                positions.Add(textPosition - searchPosition);
                searchPosition = prefix[searchPosition - 1];
            }
            else
            {
                if (textPosition < textLength && 
                    !AreEqualCharacters(searchValueSpan[searchPosition], textSpan[textPosition]))
                {
                    if (searchPosition != 0)
                        searchPosition = prefix[searchPosition - 1];
                    else
                        textPosition++;
                }
            }
        }

        return positions;
    }
}
