public static class StringMethods
{
    public static List<string> CheckForInvalid(List<string> strings, HashSet<char> criteria)
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

    public static List<string> CheckForInvalidLINQ(List<string> strings, HashSet<char> criteria)
    {
        return strings.Where(str => str.Any(criteria.Contains)).ToList();
    }

    public static List<string> CheckForInvalidLINQHeader(List<string> strings, HashSet<char> criteria)
    {
        var result = from str in strings
                     where str.Any(criteria.Contains)
                     select str;

        return result.ToList();
    }

    public static List<string> CheckForInvalidRegEx(List<string> strings, HashSet<char> criteria) 
    {
        Regex invalidChars = new Regex("[" + Regex.Escape(string.Join("", criteria)) + "]");
        List<string> result = new List<string>();

        foreach (var str in strings) { if (invalidChars.IsMatch(str)) { result.Add(str); } }

        return result;
    }

    public static List<string> GetFileNames(List<string> paths)
    {
        List<string> result = new List<string>();

        foreach (var path in paths)
        {
            if (Path.GetFileName(path) != "") { result.Add(Path.GetFileName(path)); }
        }

        return result;
    }

    public static string RemoveInvalidChars(string path, HashSet<char> criteria)
    {
        return criteria.Aggregate(path, (a, b) => a.Replace(b.ToString(), ""));
    }
}