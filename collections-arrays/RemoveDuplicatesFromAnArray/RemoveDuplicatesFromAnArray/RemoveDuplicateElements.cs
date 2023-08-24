namespace RemoveDuplicatesFromAnArray;

public class RemoveDuplicateElements
{
    public string[] WithDistinctLINQMethod(string[] arrayWithDuplicateValues)
    {
        return arrayWithDuplicateValues.Distinct().ToArray();
    }

    public string[] WithGroupByAndSelectLINQMethod(string[] arrayWithDuplicateValues)
    {
        return arrayWithDuplicateValues.GroupBy(d => d).Select(d => d.First()).ToArray();
    }

    public T[] ByHashing<T>(T[] arrayWithDuplicateValues)
    {
        return arrayWithDuplicateValues.ToHashSet().ToArray();
    }

    public T[] ByConvertingToHashSet<T>(T[] arrayWithDuplicateValues)
    {
        var hashSet = new HashSet<T>(arrayWithDuplicateValues);
        return hashSet.ToArray();
    }

    // This method will re-arrange the elements in the array
    public string[] IterationAndShiftingElements(string[] arrayWithDuplicateValues)
    {
        var size = arrayWithDuplicateValues.Length;

        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (arrayWithDuplicateValues[i] == arrayWithDuplicateValues[j])
                {
                    for (int k = j; k < size - 1; k++)
                    {
                        arrayWithDuplicateValues[k] = arrayWithDuplicateValues[k + 1];
                    }
                    j--;
                    size--;
                }
            }
        }

        return arrayWithDuplicateValues[0..size];
    }

    public string[] IterationAndSwappingElements(string[] arrayWithDuplicateValues)
    {
        var size = arrayWithDuplicateValues.Length;

        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (arrayWithDuplicateValues[i] == arrayWithDuplicateValues[j])
                {
                    size--;
                    arrayWithDuplicateValues[j] = arrayWithDuplicateValues[size];
                    j--;
                }
            }
        }

        return arrayWithDuplicateValues[0..size];
    }

    public string[] IterationWithDictionary(string[] arrayWithDuplicateValues)
    {
        var dic = new Dictionary<string, int>();

        foreach (var s in arrayWithDuplicateValues)
        {
            dic.TryAdd(s, 1);
        }

        return dic.Select(x => x.Key.ToString()).ToArray();
    }

    public string[] IterationWithDictionaryOpt(string[] arrayWithDuplicateValues)
    {
        var dic = new Dictionary<string, int>();

        foreach (var s in arrayWithDuplicateValues)
        {
            dic.TryAdd(s, 1);
        }

        return dic.Keys.ToArray();
    }

    public string[] RecursiveMethod(string[] arrayWithDuplicateValues, List<string>? mem = default, int index = 0)
    {
        if (mem == null)
        {
            mem = new List<string>();
        }

        if (index >= arrayWithDuplicateValues.Length)
        {
            return arrayWithDuplicateValues;
        }

        if (mem.IndexOf(arrayWithDuplicateValues[index]) < 0)
        {
            mem.Add(arrayWithDuplicateValues[index]);
        }

        RecursiveMethod(arrayWithDuplicateValues, mem, index + 1);

        return mem.ToArray();
    }
}

