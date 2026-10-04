namespace RemoveDuplicatesFromLists;

public class RemoveDuplicatesHelper<T> where T : notnull
{
    public RemoveDuplicatesHelper()
    {
        ListWithDuplicates = new List<T>();
    }

    public List<T> ListWithDuplicates { get; set; }

    public List<T> UsingDistinct()
    {
        return ListWithDuplicates.Distinct().ToList();
    }

    public List<T> UsingGroupBy()
    {
        return ListWithDuplicates.GroupBy(x => x).Select(d => d.First()).ToList();
    }

    public List<T> UsingUnion()
    {
        return ListWithDuplicates.Union(ListWithDuplicates).ToList();
    }

    public List<T> ConvertingToHashSet()
    {
        return ListWithDuplicates.ToHashSet().ToList();
    }

    public List<T> InitializingAHashSet()
    {
        return new HashSet<T>(ListWithDuplicates).ToList();
    }

    public List<T> UsingDictionary()
    {
        var dic = new Dictionary<T, int>();
        foreach (var s in ListWithDuplicates)
        {
            dic.TryAdd(s, 1);
        }

        var distinctList = dic.Keys.ToList();

        return distinctList;
    }

    public List<T> UsingEmptyListWithContains()
    {
        var listWithoutDuplicates = new List<T>();

        foreach (T item in ListWithDuplicates)
        {
            if (!listWithoutDuplicates.Contains(item))
            {
                listWithoutDuplicates.Add(item);
            }
        }

        return listWithoutDuplicates;
    }

    public List<T> UsingEmptyListWithAny()
    {
        var listWithoutDuplicates = new List<T>();

        foreach (T item in ListWithDuplicates)
        {
            if (!listWithoutDuplicates.Any(x => x.Equals(item)))
            {
                listWithoutDuplicates.Add(item);
            }
        }

        return listWithoutDuplicates;
    }

    public void RemoveDuplicatesInPlace()
    {
        var seen = new HashSet<T>();
        ListWithDuplicates.RemoveAll(x => !seen.Add(x));
    }

    public List<T> UsingIterationsAndShifting()
    {
        var list = new List<T>(ListWithDuplicates);
        var n = list.Count;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (list[i].Equals(list[j]))
                {
                    for (int k = j; k < n - 1; k++)
                    {
                        list[k] = list[k + 1];
                    }
                    j--;
                    n--;
                }
            }
        }

        return list.Take(n).ToList();
    }

    public List<T> UsingIterationsAndSwapping()
    {
        var list = new List<T>(ListWithDuplicates);
        var size = list.Count;

        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (list[i].Equals(list[j]))
                {
                    size--;
                    (list[j], list[size]) = (list[size], list[j]);
                    j--;
                }
            }
        }

        return list.Take(size).ToList();
    }

    public List<T> UsingRecursion(List<T>? listWithoutDuplicates = default, int index = 0)
    {
        if (listWithoutDuplicates == null)
        {
            listWithoutDuplicates = new List<T>();
        }
        if (index >= ListWithDuplicates.Count)
        {
            return listWithoutDuplicates;
        }
        if (listWithoutDuplicates.IndexOf(ListWithDuplicates[index]) < 0)
        {
            listWithoutDuplicates.Add(ListWithDuplicates[index]);
        }

        UsingRecursion(listWithoutDuplicates, index + 1);

        return listWithoutDuplicates.ToList();
    }

    public List<T> Sorting()
    {
        var listWithoutDuplicates = new List<T>();
        ListWithDuplicates = ListWithDuplicates.OrderBy(x => x).ToList();
        T? element = default;
        foreach (T result in ListWithDuplicates)
        {
            if (listWithoutDuplicates.Count == 0 || !result.Equals(element))
            {
                listWithoutDuplicates.Add(result);
                element = result;
            }
        }

        return listWithoutDuplicates;
    }
}
