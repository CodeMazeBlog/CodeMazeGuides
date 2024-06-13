using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingKMPAlgorithm : SearchBase, ISearcher
{
    private int[] prefix = [];

    private void ComputePrefix(string searchText)
    {
        char[] chars = searchText.ToCharArray();
        prefix = new int[chars.Length];

        var len = 0;
        var positions = 1;
        while (positions < chars.Length)
        {
            if (chars[positions] == chars[len])
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

    public List<int> FindAll(string text, string searchText)
    {
        if (SkipWholeFoundText)
            throw new NotSupportedException("SkipWholeFoundText is not supported for KMP algorithm.");

        ComputePrefix(searchText);

        List<int> positions = [];

        var textSpan = text.AsSpan();
        var searchTextSpan = searchText.AsSpan();

        var textLength = textSpan.Length;
        var searchLen = searchTextSpan.Length;

        var textPosition = 0;
        var searchPosition = 0;

        Func<char, char, bool> AreEqualCharacters =
            CaseSensitive ? AreEqualCharactersSensitive : AreEqualCharactersInsensitive;

        while (textPosition < textLength)
        {
            if (AreEqualCharacters(searchTextSpan[searchPosition], textSpan[textPosition]))
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
                if ((textPosition < textLength) &&
                    !(AreEqualCharacters(searchTextSpan[searchPosition], textSpan[textPosition])))
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
