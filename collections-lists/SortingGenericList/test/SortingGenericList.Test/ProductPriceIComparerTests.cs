namespace SortingGenericList.Test;

public class ProductPriceIComparerTests
{
    private readonly ProductPriceIComparer _comparer = new();

    [Fact]
    public void Compare_SameReference_ShouldReturnZero()
    {
        var productA = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};
        Assert.Equal(0, _comparer.Compare(productA, productA));
    }

    [Fact]
    public void Compare_BothNull_ShouldReturnZero()
    {
        Assert.Equal(0, _comparer.Compare(null, null));
    }

    [Fact]
    public void Compare_AIsNull_ShouldReturnNegative()
    {
        Assert.True(_comparer.Compare(null, new Product("ProductNameB", "Category", 100m) {Id = Guid.NewGuid()}) < 0);
    }

    [Fact]
    public void Compare_BIsNull_ShouldReturnPositive()
    {
        Assert.True(_comparer.Compare(new Product("ProductNameA", "Category", 100m) {Id = Guid.NewGuid()}, null) > 0);
    }

    [Fact]
    public void Compare_PriceOfAIsLessThanPriceOfB_ShouldReturnNegative()
    {
        var productA = new Product("ProductNameA", "Category", 90m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductNameB", "Category", 100m) {Id = Guid.NewGuid()};

        Assert.True(_comparer.Compare(productA, productB) < 0);
    }

    [Fact]
    public void Compare_PriceOfAIsGreaterThanPriceOfB_ShouldReturnPositive()
    {
        var productA = new Product("ProductNameA", "Category", 100m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductNameB", "Category", 90m) {Id = Guid.NewGuid()};

        Assert.True(_comparer.Compare(productA, productB) > 0);
    }

    [Fact]
    public void Compare_PriceOfAIsEqualToPriceOfB_ShouldReturnZero()
    {
        var productA = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};

        Assert.Equal(0, _comparer.Compare(productA, productB));
    }

    [Fact]
    public void Compare_PriceOfAIsEqualToPriceOfB_AndProductNamesDifferent_ShouldReturnCorrect()
    {
        var productA = new Product("ProductNameA", "Category", 100m) {Id = Guid.NewGuid()};
        var productB = new Product("ProductNameB", "Category", 100m) {Id = Guid.NewGuid()};

        Assert.True(_comparer.Compare(productA, productB) < 0);
    }
}
