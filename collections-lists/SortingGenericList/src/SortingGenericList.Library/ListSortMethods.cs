namespace SortingGenericList.Library;

public static class ListSortMethods
{
    public static void SortListInPlaceWithSort<T>(List<T> list) where T : IComparable<T>
    {
        list.Sort();
    }

    public static void SortListInPlaceWithSort<T>(List<T> list, IComparer<T> comparer)
    {
        list.Sort(comparer);
    }

    public static void SortListInPlaceWithSort<T>(List<T> list, Comparison<T> comparison)
    {
        list.Sort(comparison);
    }

    public static IEnumerable<T> SortListWithOrder<T>(List<T> list) where T : IComparable<T> => list.Order();

    public static IEnumerable<T> SortListWithOrderBy<T, TKey>(List<T> list, Func<T, TKey> orderByFunc) =>
        list.OrderBy(orderByFunc);

    public static IEnumerable<T> SortListWithOrderDescending<T>(List<T> list) where T : IComparable<T> =>
        list.OrderDescending();

    public static IEnumerable<T> SortListWithOrderByDescending<T, TKey>(List<T> list, Func<T, TKey> orderByFunc) =>
        list.OrderByDescending(orderByFunc);
}