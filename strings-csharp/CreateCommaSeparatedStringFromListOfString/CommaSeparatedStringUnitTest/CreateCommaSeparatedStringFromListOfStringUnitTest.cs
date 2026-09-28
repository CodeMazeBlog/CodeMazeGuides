using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CommaSeparatedStringUnitTest;

public class CreateCommaSeparatedStringFromListOfStringUnitTest
{
    private readonly List<string> _fruitList =
    [
        "apple",
        "orange",
        "pineapple",
        "grape",
        "coconut"
    ];

    [Fact]
    public void GivenStringJoin_WhenListOfStringIsPassed_ThenReturnCommaSeparatedString()
    {
        Assert.Equal("apple,orange,pineapple,grape,coconut", string.Join(",", _fruitList));
    }

    [Fact]
    public void GivenStringJoin_WhenListOfStringIsPassedAndFiltered_ThenReturnCommaSeparatedStringOfFilteredOutcome()
    {
        Assert.Equal("apple,pineapple", string.Join(",", _fruitList.Where(fruit => fruit.Contains("apple"))));
    }

    [Fact]
    public void GivenStringJoin_WhenArrayOfStringIsPassedWithIndexSpecified_ThenReturnCommaSeparatedStringOfIndicatedIndexes()
    {
        Assert.Equal("pineapple,grape,coconut", string.Join(",", _fruitList.ToArray(), 2, 3));
    }

    [Fact]
    public void GivenStringJoin_WhenListOfIntIsPassed_ThenReturnCommaSeparatedString()
    {
        var numbers = new List<int> { 1, 2, 3 };

        Assert.Equal("1,2,3", string.Join(",", numbers));
    }

    [Fact]
    public void GivenStringJoin_WhenCharSeparatorIsUsed_ThenReturnCommaSeparatedString()
    {
        Assert.Equal("apple,orange,pineapple,grape,coconut", string.Join(',', _fruitList));
    }
}
