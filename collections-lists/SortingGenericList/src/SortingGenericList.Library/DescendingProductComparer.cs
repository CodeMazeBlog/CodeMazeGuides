using SortingGenericList.Library.DataModels;

namespace SortingGenericList.Library;

public class DescendingProductComparer : IComparer<Product>
{
    public int Compare(Product? x, Product? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;

        return y?.CompareTo(x) ?? 1;
    }
}