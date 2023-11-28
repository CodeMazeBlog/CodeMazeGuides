public static class StringMethods
{
    public static List<string> CheckForInvalid(List<string> strings, HashSet<char> criteria)
    {
        List<string> result = new List<string>(); 

        foreach (var str in strings) 
        { 
            Console.Write(str);
            foreach (var ch in criteria) 
            { 
                Console.WriteLine(ch);
                if (str.Contains(ch)) 
                { 
                    result.Add(str); 
                    break; 
                } 
            } 
        }
        Console.WriteLine(result);
        return result;
    }

    public static List<string> CheckForInvalidLINQ(IEnumerable<string> strings, HashSet<char> criteria)
    {
        return strings.Where(str => str.Any(criteria.Contains)).ToList();
    }

    public static List<string> CheckForInvalidLINQHeader(IEnumerable<string> strings, HashSet<char> criteria)
    {
        var result = from str in strings
                     where str.Any(criteria.Contains)
                     select str;

        return result.ToList();
    }

    public static List<string> CheckForInvalidRegEx(IEnumerable<string> strings, HashSet<char> criteria) 
    {
        Regex invalidChars = new Regex("[" + Regex.Escape(string.Join("", criteria)) + "]");

        return strings.Where(str => invalidChars.IsMatch(str)).ToList();
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