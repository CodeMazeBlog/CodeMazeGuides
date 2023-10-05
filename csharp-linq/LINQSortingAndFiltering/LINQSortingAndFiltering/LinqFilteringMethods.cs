namespace LINQSortingAndFiltering;

public static class LinqFilteringMethods
{
    public static bool FilterIs3DAndWidthLessThan3(Shape? s) => s is {Is3D: true, Width: < 3};

    public static IEnumerable<T> FilterNotNull<T>(this IEnumerable<T?> source)
    {
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current is null) continue;

            yield return enumerator.Current;
        }
    }
}