using SortingGenericList.Library.DataModels;

namespace SortingGenericList.Library;

public sealed class ProductPriceIComparer : IComparer<Product?>
{
    public int Compare(Product? a, Product? b)
    {
        if (ReferenceEquals(a, b)) return 0;
        if (a is null) return -1;
        if (b is null) return 1;

        var priceComparison = a.Price.CompareTo(b.Price);

        return priceComparison != 0
            ? priceComparison
            : string.Compare(a.ProductName, b.ProductName, StringComparison.OrdinalIgnoreCase);
    }
}