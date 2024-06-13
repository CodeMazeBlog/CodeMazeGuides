using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingKMPAlgorithm : SearchBase, ISearcher
{
    private int[] ComputePrefix(ReadOnlySpan<char> searchText)
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

    public List<int> FindAll(string text, string searchText)
    {
        if (SkipWholeFoundText)
            throw new NotSupportedException("SkipWholeFoundText is not supported for KMP algorithm.");

        var textSpan = text.AsSpan();
        var searchTextSpan = searchText.AsSpan();

        var prefix = ComputePrefix(searchTextSpan);

        List<int> positions = [];

        var textLength = textSpan.Length;
        var searchLength = searchTextSpan.Length;

        Func<char, char, bool> AreEqualCharacters =
            CaseSensitive ? AreEqualCharactersSensitive : AreEqualCharactersInsensitive;

        int p = 0;
        for (var i = 0; i < textLength; i++)
        {
            while (p != 0 && !AreEqualCharacters(textSpan[i], searchTextSpan[p]))
                p = prefix[p - 1];

            if (p != 0 || AreEqualCharacters(textSpan[i], searchTextSpan[p]))
                p++;

            if (p == searchLength)
            {
                positions.Add(i + 1 - searchLength);
                p = prefix[p - 1];
            }
        }

        return positions;
    }
}
