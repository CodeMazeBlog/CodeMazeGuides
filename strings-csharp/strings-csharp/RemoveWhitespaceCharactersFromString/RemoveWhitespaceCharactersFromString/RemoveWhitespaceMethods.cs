using System.Buffers;
using System.Text;
using System.Text.RegularExpressions;

namespace RemoveWhitespaceCharactersFromString;

public static partial class RemoveWhitespaceMethods
{
    public static readonly string[] AllWhitespaceCharacters =
    {
        "\u0009", // Tab
        "\u000A", // LineFeed
        "\u000B", // VerticalTab
        "\u000C", // FormFeed
        "\u000D", // CarriageReturn
        "\u0020", // Space
        "\u0085", // NextLine
        "\u00A0", // NoBreakSpace
        "\u1680", // OghamSpaceMark
        "\u2000", // EnQuad
        "\u2001", // EmQuad
        "\u2002", // EnSpace
        "\u2003", // EmSpace
        "\u2004", // ThreePerEmSpace
        "\u2005", // FourPerEmSpace
        "\u2006", // SixPerEmSpace
        "\u2007", // FigureSpace
        "\u2008", // PunctuationSpace
        "\u2009", // ThinSpace
        "\u200A", // HairSpace
        "\u2028", // LineSeparator
        "\u2029", // ParagraphSeparator
        "\u202F", // NarrowNoBreakSpace
        "\u205F", // MediumMathematicalSpace
        "\u3000" // IdeoGraphicSpace
    };

    private static readonly Regex RemoveWhitespaceCachedRegex = new(@"\s", RegexOptions.Compiled);

    [GeneratedRegex(@"\s")]
    public static partial Regex SourceGenRemoveWhitespaceRegex();

    [GeneratedRegex(@"(^\s+|\s+$)")]
    public static partial Regex SourceGenTrimWhitespaceRegex();

    public static string RemoveWhitespacesUsingStaticRegexClass(string source)
    {
        return Regex.Replace(source, @"\s", string.Empty);
    }

    public static string RemoveWhitespacesUsingCachedRegex(string source)
    {
        return RemoveWhitespaceCachedRegex.Replace(source, string.Empty);
    }

    public static string RemoveWhitespacesUsingSourceGenRegex(string source)
    {
        return SourceGenRemoveWhitespaceRegex().Replace(source, string.Empty);
    }

    public static string RemoveWhitespacesUsingLinqWithStringConcat(string source)
    {
        return string.Concat(source.Where(c => !char.IsWhiteSpace(c)));
    }

    public static string RemoveWhitespacesUsingLinqWithStringConstruct(string source)
    {
        return new string(source.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }

    public static string RemoveWhitespacesUsingReplace(string source)
    {
        foreach (var c in AllWhitespaceCharacters) source = source.Replace(c, string.Empty);

        return source;
    }

    public static string RemoveWhitespacesUsingSplitJoin(string source)
    {
        return string.Join(string.Empty, source.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
    }

    public static string RemoveWhitespacesUsingStringBuilder(string source)
    {
        var builder = new StringBuilder(source.Length);
        for (var i = 0; i < source.Length; i++)
        {
            var c = source[i];
            if (!char.IsWhiteSpace(c))
                builder.Append(c);
        }

        return source.Length == builder.Length ? source : builder.ToString();
    }

    public static string RemoveWhitespacesUsingArray(string source)
    {
        const int maxStackArray = 256; // if source is small enough, we can avoid heap allocation
        if (source.Length < maxStackArray)
            return RemoveWhitespacesSpanHelper(source, stackalloc char[source.Length]);

        // Use a pooled array for the operation to improve GC performance of our method
        var pooledArray = ArrayPool<char>.Shared.Rent(source.Length);
        try
        {
            return RemoveWhitespacesSpanHelper(source, pooledArray.AsSpan(0, source.Length));
        }
        finally
        {
            // If we rent an array from the pool, we must return it
            ArrayPool<char>.Shared.Return(pooledArray);
        }
    }

    private static string RemoveWhitespacesSpanHelper(string source, Span<char> dest)
    {
        var pos = 0;
        foreach (var c in source)
            if (!char.IsWhiteSpace(c))
                dest[pos++] = c;

        // Don't allocate a new string if no whitespace was found
        return source.Length == pos ? source : new string(dest[..pos]);
    }

    public static string TrimWhitespacesUsingStringTrim(string source)
    {
        return source.Trim();
    }

    public static string TrimWhitespacesUsingSourceGenRegex(string source)
    {
        return SourceGenTrimWhitespaceRegex().Replace(source, string.Empty);
    }
}