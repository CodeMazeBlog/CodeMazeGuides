using System.Buffers;
using FastestWayToCheckIfListIsOrdered;

namespace Tests;

public class FastestWayToCheckIfListIsOrderedTests
{
    private static readonly List<Employee> Employees =
    [
        new Employee("Jack", new DateTime(1998, 11, 1), 3_000),
        new Employee("Simon", new DateTime(1999, 4, 10), 3_000),
        new Employee("Danniel", new DateTime(2000, 3, 2), 2_500),
        new Employee("Maria", new DateTime(2001, 5, 23), 4_300),
        new Employee("Angel", new DateTime(2001, 7, 14), 1_900)
    ];

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingForLoop_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingForLoop(Employees);
        Assert.True(areOrdered);
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingArraySort_ThenShouldBeTrue()
    {
        var array = ArrayPool<Employee>.Shared.Rent(Employees.Count);
        var areOrdered = ListOrderValidator.IsOrderedUsingArraySort(Employees, array);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingEnumerator_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingEnumerator(Employees);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqSequenceEqual_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(Employees);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqOrder_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithOrder(Employees);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqZip_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingLinqWithZip(Employees);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelFor_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelFor(Employees);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForWithSpans_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForWithSpans(Employees);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForPartitioned_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitioned(Employees);
        Assert.True(areOrdered);
    }
    
    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeTrue()
    {
        var areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(Employees);
        Assert.True(areOrdered);
    }
}