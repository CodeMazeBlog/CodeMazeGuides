using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingKMPAlgorithm : SearchBase, ISearcher
{
    private int[] _prefix = [];

    public SearchUsingKMPAlgorithm(string searchText, bool skipWholeFoundText, bool caseSensitive)
        : base(searchText, skipWholeFoundText, caseSensitive)
    {
        var searchTextSpan = SearchText.AsSpan();
        _prefix = ComputePrefix(searchTextSpan);
    }

    private static int[] ComputePrefix(ReadOnlySpan<char> searchText)
    {
        var prefix = new int[searchText.Length];

        var len = 0;
        var positions = 1;
        while (positions < searchText.Length)
        {
            if (searchText[positions] == searchText[len])
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

        return prefix;
    }

    public List<int> FindAll(string text)
    {
        if (SkipWholeFoundText)
            throw new NotSupportedException("SkipWholeFoundText is not supported for KMP algorithm.");

        var textSpan = text.AsSpan();
        var searchTextSpan = SearchText.AsSpan();

        List<int> positions = [];

        var textLength = textSpan.Length;

        Func<char, char, bool> AreEqualCharacters =
            CaseSensitive ? AreEqualCharactersSensitive : AreEqualCharactersInsensitive;

        int p = 0;
        for (var i = 0; i < textLength; i++)
        {
            while (p != 0 && !AreEqualCharacters(textSpan[i], searchTextSpan[p]))
                p = _prefix[p - 1];

            if (p != 0 || AreEqualCharacters(textSpan[i], searchTextSpan[p]))
                p++;

            if (p == SearchTextLength)
            {
                positions.Add(i + 1 - SearchTextLength);
                p = _prefix[p - 1];
            }
        }

        return positions;
    }
}
