namespace RemoveDuplicatesFromAnArray;

public class RemoveDuplicateElements
{
    public string[] WithDistinct_Method(string[] arr)
    {
        return arr.Distinct().ToArray();
    }

    public string[] WithGroupByandSelect(string[] arr)
    {
        return arr.GroupBy(d => d).Select(d => d.First()).ToArray();

    }

    public T[] ByHashing<T>(T[] arr)
    {
        return arr.ToHashSet().ToArray();

    }

    public T[] ByCreatingHashSet<T>(T[] arr)
    {
        var hashSet = new HashSet<T>(arr);
        return hashSet.ToArray();

    }

    public string[] UsingForLoop(string[] arr)
    {
        var size = arr.Length;
        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (arr[i] == arr[j])
                {
                    for (int k = j; k < size - 1; k++)
                    {
                        arr[k] = arr[k + 1];
                    }
                    j--;
                    size--;
                }
            }

        }
        return arr[0..size];

    }

    public string[] UsingForLoopWithDictionary(string[] arr)
    {
        var dic = new Dictionary<string, int>();
        foreach (var s in arr)
        {
            dic.TryAdd(s, 1);
        }

        return dic.Select(x => x.Key.ToString()).ToArray();
    }

    public string[] UsingRecursion(string[] arr, List<string>? mem = default)
    {
        if (mem == null)
        {
            mem = new List<string>();
        }

        if (arr.Length <= 1)
        {
            return arr;
        }

        if (mem.IndexOf(arr[0]) < 0)
        {
            mem.Add(arr[0]);
            UsingRecursion(arr[1..(arr.Length - 1)], mem);
        }
        else
        {
            UsingRecursion(arr[1..(arr.Length - 1)], mem);
        }

        return mem.ToArray();
    }

}

