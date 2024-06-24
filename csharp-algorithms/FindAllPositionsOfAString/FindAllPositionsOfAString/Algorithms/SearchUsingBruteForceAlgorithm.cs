using FindAllPositionsOfAString.Algorithms.Interfaces;
using System.Buffers;
using System.Reflection.Metadata.Ecma335;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingBruteForceAlgorithm : SearchBase, ISearcher
{
    public SearchUsingBruteForceAlgorithm(string searchText, bool skipWholeFoundText, bool caseSensitive)
        : base(searchText, skipWholeFoundText, caseSensitive)
    {
    }

    public List<int> FindAll(string text)
    {
        List<int> positions = [];
        var textSpan = text.AsSpan();
        var searchTextSpan = SearchText.AsSpan();

        var textLength = textSpan.Length;

        Func<char, char, bool> AreEqualCharacters = 
            CaseSensitive ? AreEqualCharactersSensitive : AreEqualCharactersInsensitive;

        int searchPosition = 0;
        for (var textPosition = 0; textPosition <= textLength - SearchTextLength; textPosition++)
        {
            for (searchPosition = 0; searchPosition < SearchTextLength; searchPosition++)
            {
                if (!AreEqualCharacters(textSpan[textPosition + searchPosition], searchTextSpan[searchPosition]))
                    break;
            }

            if (searchPosition == SearchTextLength)
            {
                positions.Add(textPosition);
                textPosition += SkipSize - 1;
            }
        }

        return positions;
    }
}
