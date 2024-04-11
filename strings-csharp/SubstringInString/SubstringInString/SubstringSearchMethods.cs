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

    public static List<int> FindAllIndexesWithSpan(ReadOnlySpan<char> input, ReadOnlySpan<char> search)
    {
        var indexes = new List<int>();
        var inputSpan = input;
        var searchSpan = search;

        for (int i = 0; i <= input.Length - search.Length; i++)
        {
            if (inputSpan.Slice(i, search.Length).SequenceEqual(searchSpan))
            {
                indexes.Add(i);
            }
        }

        return indexes;
    }

    public static List<int> FindAllIndexesWithIndexOf(ReadOnlySpan<char> input, ReadOnlySpan<char> search)
    {
        var indexes = new List<int>();
        var searchLength = search.Length;
        var inputLength = input.Length;

        for (int i = 0; i <= inputLength - searchLength; i++)
        {
            if (input.Slice(i, searchLength).SequenceEqual(search))
            {
                indexes.Add(i);
            }
        }

        return indexes;
    }

    public static List<int> FindAllIndexesWithRegex(string input, Regex regex)
    {
        var indexes = new List<int>();
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            indexes.Add(match.Index);
        }

        return indexes;
    }

    public static List<int> FindAllIndexesWithLINQ(ReadOnlySpan<char> input, ReadOnlySpan<char> search)
    {
        var indexes = new List<int>();

        if (input.Length >= search.Length)
        {
            var inputArray = input.ToArray();
            var searchArray = search.ToArray();

            indexes = Enumerable.Range(0, input.Length - search.Length + 1)
                .Where(i =>
                {
                    var inputSlice = new ReadOnlySpan<char>(inputArray, i, searchArray.Length);
                    return inputSlice.SequenceEqual(searchArray);
                })
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

    public static void PrintResult(List<int> result)
    {
        Console.WriteLine("Indexes where the substring is found: " + string.Join(", ", result));
    }
}
