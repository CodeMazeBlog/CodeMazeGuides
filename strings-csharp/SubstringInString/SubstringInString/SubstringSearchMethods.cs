using System.Text.RegularExpressions;

public static partial class SubstringSearchMethods
{
    public static List<int> FindAllIndexesWithSubstring(string input, string search)
    {
        var indexes = new List<int>();

        for (var i = 0; i <= input.Length - search.Length; i++)
        {
            if (input.Substring(i, search.Length) == search)
            {
                indexes.Add(i);
            }
        }

        return indexes;
    }
    public static void PrintResult(List<int> result)
    {
        Console.WriteLine("Indexes where the substring is found: " + string.Join(", ", result));
    }
    public static List<int> FindAllIndexesWithSpan(string input, string search)
    {
        var indexes = new List<int>();
        var inputSpan = input.AsSpan();
        var searchSpan = search.AsSpan();

        for (int i = 0; i <= input.Length - search.Length; i++)
        {
            if (inputSpan.Slice(i, search.Length).SequenceEqual(searchSpan))
            {
                indexes.Add(i);
            }
        }

        return indexes;
    }
    public static List<int> FindAllIndexesWithIndexOf(string input, string search)
    {
        var indexes = new List<int>();
        var startIndex = 0;

        do
        {
            startIndex = input.IndexOf(search, startIndex);
            if (startIndex != -1)
            {
                indexes.Add(startIndex);
                startIndex++;
            }
        }
        while (startIndex != -1);

        return indexes;
    }
    public static List<int> FindAllIndexesWithRegex(string input, string search)
    {
        var indexes = new List<int>();
        var regex = new Regex(@"\b" + Regex.Escape(search) + @"\b", RegexOptions.IgnoreCase);

        for (int i = 0; i < input.Length - search.Length + 1; i++)
        {
            if (regex.IsMatch(input.AsSpan(i, search.Length)))
            {
                indexes.Add(i);
            }
        }

        return indexes;
    }
    public static List<int> FindAllIndexesWithLINQ(string input, string search)
    {
        var indexes = new List<int>();

        if (input.Length >= search.Length)
        {
            indexes = Enumerable.Range(0, input.Length - search.Length + 1)
                .Where(i => Enumerable.Range(0, search.Length).All(j => input[i + j] == search[j]))
                .ToList();
        }

        return indexes;
    }
    public static List<int> FindAllIndexesWithSplit(string input, string search)
    {
        var indexes = new List<int>();
        var parts = input.Split(new[] { search }, StringSplitOptions.None);
        var index = 0;

        for (int i = 0; i < parts.Length - 1; i++)
        {
            index += parts[i].Length;
            indexes.Add(index);
            index += search.Length;
        }

        return indexes;
    }
}
