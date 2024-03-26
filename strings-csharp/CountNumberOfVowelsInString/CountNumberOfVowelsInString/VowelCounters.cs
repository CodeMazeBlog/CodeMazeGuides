using System.Text.RegularExpressions;
namespace CountNumberOfVowelsInString;

public static partial class VowelCounters
{
    [GeneratedRegex("[AEIOUaeiou]")]
    public static partial Regex regexVowels();

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

    public static int CountVowelsUsingSwitchStatement(string sentence)
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
        var total = regexVowels().Matches(sentence).Count;

        return total;
    }

    public static int CountVowelsUsingStrReplaceAndLength(string sentence)
    {
        var rxVowels = new Regex(@"[^AEIOUaeiou]+");

        var total = rxVowels.Replace(sentence, "").Length;

        return total;
    }

    public static int CountVowelsUsingLinq(string sentence, HashSet<char> vowels)
    {
        var total = sentence.Count(x => vowels.Contains(x));

        return total;
    }
}
