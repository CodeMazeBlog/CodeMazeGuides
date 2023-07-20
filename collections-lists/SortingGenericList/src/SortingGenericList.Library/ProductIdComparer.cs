using SortingGenericList.Library.DataModels;

namespace SortingGenericList.Library;

public sealed class ProductIdComparer : Comparer<Product?>
{
    public override int Compare(Product? a, Product? b)
    {
        if (ReferenceEquals(a, b)) return 0;
        if (a is null) return -1;
        if (b is null) return 1;

        return a.Id.CompareTo(b.Id);
    }
}