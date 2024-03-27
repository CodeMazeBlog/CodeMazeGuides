using System.Buffers;
using System.Text.RegularExpressions;

namespace CountNumberOfVowelsInString;

public static partial class VowelCounters
{
    [GeneratedRegex(@"[AEIOUaeiou]")]
    private static partial Regex _regexVowels();

    [GeneratedRegex(@"[^AEIOUaeiou]+")]
    private static partial Regex _regexNotVowels();

    public static int CountVowelsUsingSearchValues(ReadOnlySpan<char> sentence, SearchValues<char> vowelsSearchValues)
    {
        var count = 0;
        for (var i = 0; i < sentence.Length; ++i)
        {
            if (vowelsSearchValues.Contains(sentence[i]))
                ++count;
        }

        return count;
    }

    public static int CountVowelsUsingForLoop(ReadOnlySpan<char> sentence, ReadOnlySpan<char> vowels)
    {
        var total = 0;

        for (var i = 0; i < sentence.Length; i++)
        {
            if (vowels.Contains(sentence[i]))
            {
                total++;
            }
        }

        return total;
    }

    public static int CountVowelsUsingForEachLoop(ReadOnlySpan<char> sentence, ReadOnlySpan<char> vowels)
    {
        var total = 0;

        foreach (var c in sentence)
        {
            if (vowels.Contains(c))
            {
                total++;
            }
        }

        return total;
    }

    public static int CountVowelsUsingSwitchStatement(ReadOnlySpan<char> sentence)
    {
        var total = 0;

        foreach (var c in sentence)
        {
            switch (c)
            {
                case 'A':
                case 'a':
                case 'E':
                case 'e':
                case 'I':
                case 'i':
                case 'O':
                case 'o':
                case 'U':
                case 'u':
                    total++;
                    break;
                default:
                    break;
            }

        }

        return total;
    }

    public static int CountVowelsUsingRegEx(string sentence)
    {
        return _regexVowels().Matches(sentence).Count;
    }

    public static int CountVowelsUsingRegexReplaceAndLength(string sentence)
    {
        return _regexNotVowels().Replace(sentence, "").Length;
    }

    public static int CountVowelsUsingLinq(string sentence, HashSet<char> vowels)
    {
        return sentence.Count(x => vowels.Contains(x));
    }
}
