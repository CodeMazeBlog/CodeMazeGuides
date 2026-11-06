using System.Globalization;

namespace StringToTitleCase;

public static class TitleCaseExtensions
{
    private static readonly HashSet<string> MinorWords = new(StringComparer.OrdinalIgnoreCase)
    {
        "a", "an", "and", "as", "at", "but", "by", "for", "in", "nor", "of", "on", "or", "the", "to"
    };

    public static string ToTitleCaseWithMinorWords(this string input, TextInfo textInfo)
    {
        var words = textInfo.ToTitleCase(textInfo.ToLower(input)).Split(' ');

        for (var i = 1; i < words.Length - 1; i++)
        {
            if (MinorWords.Contains(words[i]))
            {
                words[i] = textInfo.ToLower(words[i]);
            }
        }

        return string.Join(' ', words);
    }
}
