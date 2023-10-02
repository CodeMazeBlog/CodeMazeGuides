namespace LINQSortingAndFiltering;

public static class LinqFilteringMethods
{
    public static bool FilterIs3DAndWidthLessThan3(Shape? s) => s is {Width: < 3, Is3D: true};

    public static IEnumerable<T> FilterIsNotNull<T>(this IEnumerable<T?> source)
    {
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current is null) continue;

            yield return enumerator.Current;
        }
    }
}