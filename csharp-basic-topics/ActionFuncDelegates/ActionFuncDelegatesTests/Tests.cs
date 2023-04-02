using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ActionAndFuncDelegatesTests;

public class Tests
{
    [Fact]
    public void GivenActionAddTwoNumbers_ShouldReturnSum()
    {
        // Arrange
        Func<int, int, int> add = Add;

        // Act
        int result = add(3, 4);

        // Assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void GivenListWithThreeWords_ShouldReturnListWithLengthForEachWord()
    {
        // Arrange
        var expectedResult = new List<int>() { 5, 5, 7 };
        var words = new List<string> { "hello", "world", "goodbye" };

        // Act
        var lengths = words.Select(s => s.Length).ToList();

        // Assert
        Assert.Equal(expectedResult, lengths);
    }

    [Fact]
    public void GivenListWithNumber_ShouldReturnNumberGreaterThanFive()
    {
        // Arrange
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Act
        List<int> filteredNumbers = numbers.Where(n => n > 5).ToList();

        // Assert
        Assert.All(filteredNumbers, number => Assert.True(number > 5));
    }

    static int Add(int a, int b)
    {
        return a + b;
    }

}