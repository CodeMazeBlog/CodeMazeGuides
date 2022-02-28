public static class ListExtensionsWithDelegates
{
    public delegate bool PredicateItem<T>(T x);

    public delegate void DoSomethingEachItem<T>(T x);

    public static IEnumerable<T> WhereWithDelegate<T>(this List<T> list, PredicateItem<T> predicate)
    {
        foreach (var item in list)
        {
            if(predicate(item))
                yield return item;
        }
    }

    public static void ForEachWithDelegate<T>(this List<T> list, DoSomethingEachItem<T> doSometing)
    {
        foreach (var item in list)
        {
            doSometing(item);
        }
    }
}
