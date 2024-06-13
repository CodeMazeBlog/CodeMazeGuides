using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Buffers;
using System.Reflection.Metadata.Ecma335;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingBruteForceAlgorithm : SearchBase, ISearcher
{
    public List<int> FindAll(string text, string searchText)
    {
        List<int> positions = [];
        var textSpan = text.AsSpan();
        var searchTextSpan = searchText.AsSpan();

        var textLength = textSpan.Length;
        var searchLen = searchTextSpan.Length;

        Func<char, char, bool> AreEqualCharacters = 
            CaseSensitive ? AreEqualCharactersSensitive : AreEqualCharactersInsensitive;

        int searchPosition = 0;
        for (var textPosition = 0; textPosition <= textLength - searchLen; textPosition++)
        {
            for (searchPosition = 0; searchPosition < searchLen; searchPosition++)
            {
                if (!AreEqualCharacters(textSpan[textPosition + searchPosition], searchTextSpan[searchPosition]))
                    break;
            }

            if (searchPosition == searchLen)
            {
                positions.Add(textPosition);
                if (SkipWholeFoundText)
                    textPosition += searchLen - 1;
            }
        }

        return positions;
    }
}
