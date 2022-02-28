public static class ListExtensionsWithoutDelegates
{
    public static IEnumerable<T> WhereWithFunc<T>(this List<T> list, Func<T, bool> predicate)
    {
        foreach (var item in list)
        {
            if (predicate(item))
                yield return item;
        }
    }

    public static void ForEachWithAction<T>(this List<T> list, Action<T> doSometing)
    {
        foreach (var item in list)
        {
            doSometing(item);
        }
    }
}
