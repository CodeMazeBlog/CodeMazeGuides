namespace RemoveDuplicatesFromLists;

public class RemoveDuplicatesHelper<T>
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

    public List<T> UsingIterationsAndShifting()
    {
        var n = ListWithDuplicates.Count;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (ListWithDuplicates.ElementAt(i)!.Equals(ListWithDuplicates.ElementAt(j)))
                {
                    for (int k = j; k < n - 1; k++)
                    {
                        T item = ListWithDuplicates.ElementAt(k);
                        item = ListWithDuplicates.ElementAt(k + 1);
                    }
                    j--;
                    n--;
                }
            }
        }

        return ListWithDuplicates.Take(n).ToList();
    }

    public List<T> UsingIterationsAndSwapping()
    {
        var size = ListWithDuplicates.Count;
        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (ListWithDuplicates.ElementAt(i)!.Equals(ListWithDuplicates.ElementAt(j)))
                {
                    size--;
                    T jThItem = ListWithDuplicates.ElementAt(j);
                    jThItem = ListWithDuplicates.ElementAt(size);
                    j--;
                }
            }
        }

        return ListWithDuplicates.Take(size).ToList();
    }

    public List<T> UsingRecursion(List<T>? listWithoutDuplicates = default, int index = 0)
    {
        if (listWithoutDuplicates == null)
        {
            listWithoutDuplicates = new List<T>();
        }
        if (index >= ListWithDuplicates.Count)
        {
            return ListWithDuplicates;
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
            if (!result!.Equals(element))
            {
                listWithoutDuplicates.Add(result);
                element = result;
            }
        }

        return listWithoutDuplicates;
    }
}
