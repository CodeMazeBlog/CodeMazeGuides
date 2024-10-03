using PointersInCSharp.Method;

namespace PointersInCSharp.Tests;

public class UnitTests
{
    [Fact]
    public unsafe void GivenSwapCharsMethod_WhenTwoChars_ThenSwapValues()
    {
        char char1 = 'A';
        char char2 = 'B';
        char* p1 = &char1;
        char* p2 = &char2;

        Methods.SwapChars(p1, p2);

        Assert.Equal('B', char1);
        Assert.Equal('A', char2);
    }

    [Fact]
    public unsafe void GivenDoubleOddValuesMethod_WhenPositiveNumbers_ThenDoubleOddValues()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        Methods.DoubleOddValues(numbers);

        Assert.Equal([2, 2, 6, 4, 10], numbers);
    }

    [Fact]
    public unsafe void GivenDoubleOddValuesMethod_WhenNegativeNumbers_ThenValuesDoubled()
    {
        var numbers = new[] { -1, -2, -3, -4, -5 };
        Methods.DoubleOddValues(numbers);

        Assert.Equal([-2, -2, -6, -4, -10], numbers);
    }

    [Fact]
    public unsafe void GivenSwapCharsMethod_WhenNullPointer_ThenThrowsNullReferenceException()
    {
        char* p1 = null;
        char* p2 = null;

        Assert.Throws<NullReferenceException>(() => Methods.SwapChars(p1, p2));
    }

    [Fact]
    public unsafe void GivenDoubleOddValuesMethod_WhenEmptyArray_ThenEmptyArray()
    {
        var numbers = Array.Empty<int>();
        Methods.DoubleOddValues(numbers);

        Assert.Equal([], numbers);
    }
}