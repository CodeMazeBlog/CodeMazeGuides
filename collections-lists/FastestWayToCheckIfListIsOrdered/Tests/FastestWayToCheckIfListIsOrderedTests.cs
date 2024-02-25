using FastestWayToCheckIfListIsOrdered;

namespace Tests;

public class FastestWayToCheckIfListIsOrderedTests
{
    private static readonly List<Employee> OrderedEmployees =
    [
        new Employee("Jack", new DateTime(1998, 11, 1), 3_000),
        new Employee("Simon", new DateTime(1999, 4, 10), 3_000),
        new Employee("Daniel", new DateTime(2000, 3, 2), 2_500),
        new Employee("Maria", new DateTime(2001, 5, 23), 4_300),
        new Employee("Angel", new DateTime(2001, 7, 14), 1_900)
    ];

    private static readonly List<Employee> OutOfOrderEmployees =
    [
        new Employee("Alice", new DateTime(2003, 11, 1), 3_000),
        new Employee("Grace", new DateTime(1999, 4, 10), 3_000),
        new Employee("Henry", new DateTime(2000, 3, 2), 2_500),
        new Employee("Isabella", new DateTime(1998, 5, 23), 4_300),
        new Employee("Mario", new DateTime(2005, 7, 14), 1_900)
    ];

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingForLoop_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingForLoop(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingForLoop_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingForLoop(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingArraySort_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingArraySort(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingArraySort_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingArraySort(OutOfOrderEmployees);
        
        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingEnumerator_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingEnumerator(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingEnumerator_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingEnumerator(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingSpans_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingSpans(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingSpans_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingSpans(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqSequenceEqual_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingLinqSequenceEqual_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqOrder_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithOrder(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingLinqOrder_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithOrder(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqZip_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithZip(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingLinqZip_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithZip(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelFor_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelFor(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingParallelFor_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelFor(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForWithSpans_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForWithSpans(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingParallelForWithSpans_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForWithSpans(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForPartitioned_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitioned(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingParallelForPartitioned_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitioned(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(OrderedEmployees);

        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeFalse()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(OutOfOrderEmployees);

        Assert.False(areOrdered);
    }
}