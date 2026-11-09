namespace SortingGenericList.Test.DataModelsTests;

public sealed class ProductTests
{
    [Fact]
    public void Product_Default_Id_Should_Not_Be_Empty()
    {
        var product = new Product("Product A", "Category1", 10.0m);
        Assert.NotEqual(Guid.Empty, product.Id);
    }

    [Fact]
    public void Product_Comparisons_Should_Be_Correct()
    {
        var product1 = new Product("Product A", "Category1", 10.0m);
        var product2 = new Product("Product B", "Category1", 10.0m);
        var product3 = new Product("Product A", "Category1", 20.0m);

        Assert.True(product1 < product2);
        Assert.True(product1 <= product2);
        Assert.True(product2 > product1);
        Assert.True(product2 >= product1);

        Assert.NotEqual(product1, product3);
        Assert.True(product1.CompareTo(product3) < 0);

        Assert.Equal(0, product1.CompareTo(product1));
    }

    [Fact]
    public void Product_Comparison_With_Null_Should_Be_Correct()
    {
        var product = new Product("Product A", "Category1", 10.0m);

        var exception = Assert.Throws<ArgumentException>(() => product.CompareTo(new object()));
        Assert.Equal($"Object must be of type {nameof(Product)}", exception.Message);

        Assert.Equal(1, product.CompareTo(null));
    }

    [Fact]
    public void ShouldCorrectlyPerformDescendComparison_ForSameProducts_Ascending()
    {
        var product1 = new Product("Apple", "Fruits", 1m);
        var product2 = new Product("Banana", "Fruits", 2m);

        var result = Product.DescendingCompare(product1, product2);

        Assert.True(result > 0);
    }

    [Fact]
    public void ShouldCorrectlyPerformDescendComparison_ForSameProducts_Descending()
    {
        var product1 = new Product("Pear", "Fruits", 1m);
        var product2 = new Product("Orange", "Fruits", 2m);

        var result = Product.DescendingCompare(product1, product2);

        Assert.True(result < 0);
    }

    [Fact]
    public void ShouldCorrectlyPerformDescendComparison_ForEqualProducts()
    {
        var product1 = new Product("Pear", "Fruits", 1m);
        var product2 = new Product("Pear", "Fruits", 1m);

        var result = Product.DescendingCompare(product1, product2);

        Assert.Equal(0, result);
    }

    [Fact]
    public void DescendingCompare_ForTwoNulls_ReturnsZero()
    {
        Assert.Equal(0, Product.DescendingCompare(null, null));
    }

    [Fact]
    public void DescendingCompare_WhenListHasManyNulls_SortsWithNullsLast()
    {
        var random = new Random(1);
        var products = Enumerable.Range(0, 200)
            .Select(i => i % 5 == 0 ? null : new Product($"P{random.Next(1000):D3}", "Category", 1m))
            .ToList();

        products.Sort(Product.DescendingCompare);

        Assert.All(products.Take(160), Assert.NotNull);
        Assert.All(products.Skip(160), Assert.Null);
        Assert.Equal(
            products.Take(160).OrderByDescending(p => p!.ProductName, StringComparer.OrdinalIgnoreCase)
                .Select(p => p!.ProductName),
            products.Take(160).Select(p => p!.ProductName));
    }
}
