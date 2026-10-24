namespace SortedListInCSharp;

public static class MemoryComparison
{
    public static long RetainedBytes(Func<object> fill)
    {
        var before = GC.GetTotalMemory(forceFullCollection: true);
        var collection = fill();
        var after = GC.GetTotalMemory(forceFullCollection: true);
        GC.KeepAlive(collection);

        return after - before;
    }

    public static IDictionary<int, int> Fill(IDictionary<int, int> collection, int[] keys)
    {
        foreach (var key in keys)
        {
            collection.Add(key, key);
        }

        return collection;
    }
}
