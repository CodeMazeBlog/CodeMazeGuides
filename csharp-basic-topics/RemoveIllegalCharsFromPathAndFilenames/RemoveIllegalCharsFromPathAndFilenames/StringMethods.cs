namespace RemoveIllegalCharsFromPathAndFilenames;
public static class StringMethods
{
    public static IEnumerable<string> CheckForInvalid(IEnumerable<string> strings, HashSet<char> criteria)
    {
        List<string> result = new List<string>();

        foreach (var str in strings)
        {
            foreach (var ch in criteria)
            {
                if (str.Contains(ch))
                {
                    result.Add(str);
                    break;
                }
            }
        }

        return result;
    }

    public static IEnumerable<string> CheckForInvalidLINQ(IEnumerable<string> strings, HashSet<char> criteria)
    {
        return strings.Where(str => str.Any(criteria.Contains));
    }

    public static IEnumerable<string> CheckForInvalidLINQQuerySyntax(IEnumerable<string> strings, HashSet<char> criteria)
    {
        var result = from str in strings
                     where str.Any(criteria.Contains)
                     select str;

        return result;
    }

    public static IEnumerable<string> CheckForInvalidRegEx(IEnumerable<string> strings, HashSet<char> criteria)
    {
        Regex invalidChars = new Regex("[" + Regex.Escape(string.Join("", criteria)) + "]");

        return strings.Where(str => invalidChars.IsMatch(str));
    }

    public static IEnumerable<string> GetFileNames(IEnumerable<string> paths)
    {
        return paths.Select(path => Path.GetFileName(path)).Where(path => !string.IsNullOrEmpty(path));
    }

    public static string RemoveInvalidChars(string path, HashSet<char> criteria)
    {
        return criteria.Aggregate(path, (a, b) => a.Replace(b.ToString(), string.Empty));
    }
}
public static class StringConstants
{
    public static readonly HashSet<char> InvalidPathChars = new HashSet<char>
    {
        '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a',
        '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011',
        '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018',
        '\u0019', '\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f'
    };
    public static readonly HashSet<char> InvalidFilenameChars = new HashSet<char>(InvalidPathChars)
    {
        '"', '<', '>', ':', '*', '?', '\\', '/'
    };    
}