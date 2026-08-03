namespace SortingGenericList.Test.DataModelsTests;

public sealed class ProductTests
{
    [Fact]
    public void Product_Default_Id_Should_Not_Be_Empty()
    {
        var product = new Product("Product A", "Category1", 10.0m);
        product.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Product_Comparisons_Should_Be_Correct()
    {
        var product1 = new Product("Product A", "Category1", 10.0m);
        var product2 = new Product("Product B", "Category1", 10.0m);
        var product3 = new Product("Product A", "Category1", 20.0m);

        product1.Should().BeLessThan(product2);
        product1.Should().BeLessOrEqualTo(product2);
        product2.Should().BeGreaterThan(product1);
        product2.Should().BeGreaterOrEqualTo(product1);

        product1.Should().NotBe(product3);
        product1.CompareTo(product3).Should().BeNegative();

        product1.CompareTo(product1).Should().Be(0);
    }

    [Fact]
    public void Product_Comparison_With_Null_Should_Be_Correct()
    {
        var product = new Product("Product A", "Category1", 10.0m);

        product.Invoking(p => p.CompareTo(new object()))
               .Should().Throw<ArgumentException>().WithMessage($"Object must be of type {nameof(Product)}");

        product.CompareTo(null).Should().Be(1);
    }

    [Fact]
    public void ShouldCorrectlyPerformDescendComparison_ForSameProducts_Ascending()
    {
        var product1 = new Product("Apple", "Fruits", 1m);
        var product2 = new Product("Banana", "Fruits", 2m);

        var result = Product.DescendingCompare(product1, product2);

        result.Should().BePositive();
    }

    [Fact]
    public void ShouldCorrectlyPerformDescendComparison_ForSameProducts_Descending()
    {
        var product1 = new Product("Pear", "Fruits", 1m);
        var product2 = new Product("Orange", "Fruits", 2m);

        var result = Product.DescendingCompare(product1, product2);

        result.Should().BeNegative();
    }

    [Fact]
    public void ShouldCorrectlyPerformDescendComparison_ForEqualProducts()
    {
        var product1 = new Product("Pear", "Fruits", 1m);
        var product2 = new Product("Pear", "Fruits", 1m);

        var result = Product.DescendingCompare(product1, product2);

        result.Should().Be(0);
    }
}