using FuncAndActionDelegatesInCSharp;

namespace Tests;

public class FuncExampleTests
{
    [Fact]
    public void GivenSortedInput_WhenOrderingNumbersByAsc_ThenReturnsSameOrder()
    {
        int[] input = { 1, 2, 3, 4, 5 };
        int[] expected = { 1, 2, 3, 4, 5 };

        var result = FuncExample.OrderNumberByAsc(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenUnsortedInput_WhenOrderingNumbersByAsc_ThenReturnsAscendingOrder()
    {
        int[] input = { 5, 3, 1, 4, 2 };
        int[] expected = { 1, 2, 3, 4, 5 };

        var result = FuncExample.OrderNumberByAsc(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenNegativeNumbers_WhenOrderingNumbersByAsc_ThenReturnsAscendingOrder()
    {
        int[] input = { -3, 5, -1, 2, 0 };
        int[] expected = { -3, -1, 0, 2, 5 };

        var result = FuncExample.OrderNumberByAsc(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenEmptyInput_WhenOrderingNumbersByAsc_ThenReturnsEmptyArray()
    {
        int[] input = { };
        int[] expected = { };

        var result = FuncExample.OrderNumberByAsc(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenDuplicateNumbers_WhenOrderingNumbersByAsc_ThenReturnsAscendingOrderWithDuplicates()
    {
        int[] input = { 3, 1, 2, 1, 3 };
        int[] expected = { 1, 1, 2, 3, 3 };

        var result = FuncExample.OrderNumberByAsc(input);

        Assert.Equal(expected, result);
    }
}