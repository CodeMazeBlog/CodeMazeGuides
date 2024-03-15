namespace SortingGenericList.Test;

public class ProductIdComparerTests
{
    private readonly ProductIdComparer _comparer = new();

    [Fact]
    public void Compare_SameReference_ShouldReturnZero()
    {
        var id = Guid.NewGuid();
        var productA = new Product("ProductName", "Category", 100m) {Id = id};
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
        var productB = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};
        _comparer.Compare(null, productB).Should().BeNegative();
    }

    [Fact]
    public void Compare_BIsNull_ShouldReturnPositive()
    {
        var productA = new Product("ProductName", "Category", 100m) {Id = Guid.NewGuid()};
        _comparer.Compare(productA, null).Should().BePositive();
    }

    [Fact]
    public void Compare_AIdIsLessThanBId_ShouldReturnNegative()
    {
        var idA = Guid.Parse("00000000-0000-0000-0000-000000000000");
        var idB = Guid.NewGuid();

        _comparer.Compare(
            new Product("ProductName", "Category", 100m) {Id = idA},
            new Product("ProductName", "Category", 100m) {Id = idB})
                 .Should().BeNegative();
    }

    [Fact]
    public void Compare_AIdIsGreaterThanBId_ShouldReturnPositive()
    {
        var idA = Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF");
        var idB = Guid.NewGuid();

        _comparer.Compare(
            new Product("ProductName", "Category", 100m) {Id = idA},
            new Product("ProductName", "Category", 100m) {Id = idB}).Should().BePositive();
    }

    [Fact]
    public void Compare_AIdIsEqualToBId_ShouldReturnZero()
    {
        var id = Guid.NewGuid();

        _comparer.Compare(
            new Product("ProductName", "Category", 100m) {Id = id},
            new Product("ProductName", "Category", 100m) {Id = id}).Should().Be(0);
    }
}