namespace SortingGenericList.Library.DataModels;

public sealed record Product(string ProductName, string Category, decimal Price) : IComparable<Product>, IComparable
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public static bool operator <(Product? left, Product? right) => Comparer<Product>.Default.Compare(left, right) < 0;

    public static bool operator >(Product? left, Product? right) => Comparer<Product>.Default.Compare(left, right) > 0;

    public static bool operator <=(Product? left, Product? right) =>
        Comparer<Product>.Default.Compare(left, right) <= 0;

    public static bool operator >=(Product? left, Product? right) =>
        Comparer<Product>.Default.Compare(left, right) >= 0;

    public static int DescendingCompare(Product? a, Product? b) => b?.CompareTo(a) ?? -1;

    public int CompareTo(object? obj)
    {
        if (obj is null) return 1;
        if (ReferenceEquals(this, obj)) return 0;

        return obj is Product other
            ? CompareTo(other)
            : throw new ArgumentException($"Object must be of type {nameof(Product)}");
    }

    public int CompareTo(Product? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;

        var nameComparison = string.Compare(ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);

        return nameComparison != 0 ? nameComparison : Price.CompareTo(other.Price);
    }
}