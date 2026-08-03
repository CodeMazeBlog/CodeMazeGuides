using SortingGenericList.Library;
using SortingGenericList.Library.DataModels;

var unsortedProducts = GetProducts();
var productList = new List<Product?>(unsortedProducts.Length);

Console.WriteLine("----------List<Product> In Place Sort (Default Order: ProductName)----------");
Console.WriteLine("Products:");
PrintProducts(unsortedProducts);
Console.WriteLine();

productList.Clear();
productList.AddRange(unsortedProducts);

productList.Sort();
Console.WriteLine("**Sorted**");
PrintProducts(productList);
Console.WriteLine();

Console.WriteLine("----------List<Product> In Place Sort With IComparer (Order: Price)----------");
Console.WriteLine("Products:");
PrintProducts(unsortedProducts);
Console.WriteLine();

productList.Clear();
productList.AddRange(unsortedProducts);

productList.Sort(new ProductPriceIComparer());
Console.WriteLine("**Sorted**");
PrintProducts(productList);
Console.WriteLine();

Console.WriteLine("----------List<Product> In Place Sort With Derived Comparer<T> (Order: Id)----------");
Console.WriteLine("Products:");
PrintProducts(unsortedProducts);
Console.WriteLine();

productList.Clear();
productList.AddRange(unsortedProducts);

productList.Sort(new ProductIdComparer());
Console.WriteLine("**Sorted**");
PrintProducts(productList);
Console.WriteLine();

Console.WriteLine("----------List<Product> In Place Sort With Comparison<T> (Lambda: Order - Category)----------");
Console.WriteLine("Products:");
PrintProducts(unsortedProducts);
Console.WriteLine();

productList.Clear();
productList.AddRange(unsortedProducts);

productList.Sort((a, b) =>
{
    if (ReferenceEquals(a, b)) return 0;
    if (a is null) return -1;
    if (b is null) return 1;

    var result = string.Compare(a.Category, b.Category, StringComparison.OrdinalIgnoreCase);

    return result != 0 ? result : a.CompareTo(b);
});

Console.WriteLine("**Sorted**");
PrintProducts(productList);
Console.WriteLine();

Console.WriteLine(
    "----------List<Product> In Place Sort With Comparison<T> (Order: ProductName - Descending)----------");
Console.WriteLine("Products:");
PrintProducts(unsortedProducts);
Console.WriteLine();

productList.Clear();
productList.AddRange(unsortedProducts);

productList.Sort(Product.DescendingCompare);
Console.WriteLine("**Sorted**");
PrintProducts(productList);
Console.WriteLine();

Console.WriteLine(
    "----------List<Product> Sort Range ([0,2] - Sort Price, [3,5] - Default Sort)----------");
Console.WriteLine("Products:");
PrintProducts(unsortedProducts);
Console.WriteLine();

productList.Clear();
productList.AddRange(unsortedProducts);

productList.Sort(0, 3, new ProductPriceIComparer());
productList.Sort(3, 3, null);
Console.WriteLine("**Sorted**");
PrintProducts(productList);
Console.WriteLine();

// --------------- Local Methods and Classes ---------------
static void PrintProducts(IEnumerable<Product?> products)
{
    foreach (var value in products)
        Console.WriteLine(
            $"{value?.ProductName ?? "NULL",-30}{value?.Category ?? "NULL",-20}${value?.Price ?? 0.00m,-10:0.00}{value?.Id ?? Guid.Empty,40}");
}

static Product?[] GetProducts() =>
    new Product?[]
    {
        new("Gorgeous Fish", "Games", 103.07m) {Id = Guid.Parse("f0569e86-bfad-6f3a-b74d-2555175dcc6e")},
        new("Tasty Cheese", "Clothing", 134.74m) {Id = Guid.Parse("4af80b60-3e17-1dfd-8462-c009ca918154")},
        null,
        new("Handcrafted Hat", "Books", 38.09m) {Id = Guid.Parse("c7b30b28-db07-f2ae-70dc-9505096e676b")},
        new("Practical Chicken", "Electronics", 126.06m) {Id = Guid.Parse("d6fee4b9-8767-851a-b386-a8af727663a7")},
        new("Generic Car", "Games", 75.18m) {Id = Guid.Parse("c65100fd-e49f-f5e0-0e71-052d7eefe9b3")}
    };