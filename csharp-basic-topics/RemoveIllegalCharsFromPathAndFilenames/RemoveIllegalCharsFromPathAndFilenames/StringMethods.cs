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

    public static IEnumerable<string> CheckForInvalidLINQHeader(IEnumerable<string> strings, HashSet<char> criteria)
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
        List<string> result = new List<string>();

        return paths.Select(path => Path.GetFileName(path)).Where(path => !string.IsNullOrEmpty(path));
    }

    public static string RemoveInvalidChars(string path, HashSet<char> criteria)
    {
        return criteria.Aggregate(path, (a, b) => a.Replace(b.ToString(), String.Empty));
    }
}