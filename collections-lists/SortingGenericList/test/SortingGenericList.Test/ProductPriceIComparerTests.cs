namespace SortingGenericList.Test;

public class ProductPriceIComparerTests
{
    private readonly ProductPriceIComparer _comparer = new();

    [Fact]
    public void Compare_SameReference_ShouldReturnZero()
    {
        var productA = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};
        _comparer.Compare(productA, productA).Should().Be(0);
    }

    [Fact]
    public void Compare_BothNull_ShouldReturnZero()
    {
        _comparer.Compare(null, null).Should().Be(0);
    }

    [Fact]
    public void Compare_AIsNull_ShouldReturnNegative()
    {
        _comparer.Compare(null, new Product("ProductNameB", "Category", 100m) {Id = Guid.NewGuid()}).Should()
                 .BeNegative();
    }

    [Fact]
    public void Compare_BIsNull_ShouldReturnPositive()
    {
        _comparer.Compare(new Product("ProductNameA", "Category", 100m) {Id = Guid.NewGuid()}, null).Should()
                 .BePositive();
    }

    [Fact]
    public void Compare_PriceOfAIsLessThanPriceOfB_ShouldReturnNegative()
    {
        var productA = new Product("ProductNameA", "Category", 90m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductNameB", "Category", 100m) {Id = Guid.NewGuid()};

        _comparer.Compare(productA, productB).Should().BeNegative();
    }

    [Fact]
    public void Compare_PriceOfAIsGreaterThanPriceOfB_ShouldReturnPositive()
    {
        var productA = new Product("ProductNameA", "Category", 100m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductNameB", "Category", 90m) {Id = Guid.NewGuid()};

        _comparer.Compare(productA, productB).Should().BePositive();
    }

    [Fact]
    public void Compare_PriceOfAIsEqualToPriceOfB_ShouldReturnZero()
    {
        var productA = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};

        _comparer.Compare(productA, productB).Should().Be(0);
    }

    [Fact]
    public void Compare_PriceOfAIsEqualToPriceOfB_AndProductNamesDifferent_ShouldReturnCorrect()
    {
        var productA = new Product("ProductNameA", "Category", 100m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductNameB", "Category", 100m) {Id = Guid.NewGuid()};

        _comparer.Compare(productA, productB).Should().BeNegative();
    }
}