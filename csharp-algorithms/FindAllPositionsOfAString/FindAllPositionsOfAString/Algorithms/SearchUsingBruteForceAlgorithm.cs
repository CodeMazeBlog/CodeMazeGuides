using FindAllPositionsOfAString.Algorithms.Interfaces;

namespace FindAllPositionsOfAString.Algorithms;

public class SearchUsingBruteForceAlgorithm : SearchBase, ISearcher
{
    public List<int> FindAll(string text)
    {
        ReadOnlySpan<char> searchValueSpan = _searchText.AsSpan();
        ReadOnlySpan<char> textSpan = text.AsSpan();

        List<int> positions = [];
        var textLength = textSpan.Length;
        var searchLen = searchValueSpan.Length;

        for (var textPosition = 0; textPosition <= textLength - searchLen; textPosition++)
        {
            int searchPosition;

            for (searchPosition = 0; searchPosition < searchLen; searchPosition++)
            {
                if (!AreEqualCharacters(textSpan[textPosition + searchPosition], searchValueSpan[searchPosition]))
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
