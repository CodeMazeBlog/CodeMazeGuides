global using Xunit;
using SortDictionaryByValue;

namespace SortDictionaryByValueTests;

public class SortDictionaryByValueUnitTest
{
    [Fact]
    public void GivenUnorderedDictionary_WhenSortedUsingLinqOrderBy_ThenReturnOrderedKeyValuePairs()
    {
        var dictionary = new Dictionary<string, string>
        {
            { "1", "apple" },
            { "2", "orange" },
            { "3", "banana" },
            { "4", "grape" }
        };

        var sortedKeyValuePairs = SortDictionary.SortDictionaryValueUsingLinqOrderBy(dictionary);

        Assert.Same(sortedKeyValuePairs.ElementAt(0).Value, "apple");
        Assert.Same(sortedKeyValuePairs.ElementAt(1).Value, "banana");
        Assert.Same(sortedKeyValuePairs.ElementAt(2).Value, "grape");
        Assert.Same(sortedKeyValuePairs.ElementAt(3).Value, "orange");
    }

    [Fact]
    public void GivenUnorderedDictionary_WhenSortedUsingSortMethod_ThenReturnOrderedKeyValuePairs()
    {
        var dictionary = new Dictionary<string, string>
        {
            { "1", "apple" },
            { "2", "orange" },
            { "3", "banana" },
            { "4", "grape" }
        };

        var sortedKeyValuePairs = SortDictionary.SortDictionaryValueUsingSortMethod(dictionary);

        Assert.Same(sortedKeyValuePairs.ElementAt(0).Value, "apple");
        Assert.Same(sortedKeyValuePairs.ElementAt(1).Value, "banana");
        Assert.Same(sortedKeyValuePairs.ElementAt(2).Value, "grape");
        Assert.Same(sortedKeyValuePairs.ElementAt(3).Value, "orange");
    }

    [Fact]
    public void GivenUnorderedDictionary_WhenSortedUsingLinqQueryExpression_ThenReturnOrderedKeyValuePairs()
    {
        var dictionary = new Dictionary<string, string>
        {
            { "1", "apple" },
            { "2", "orange" },
            { "3", "banana" },
            { "4", "grape" }
        };

        var sortedKeyValuePairs = SortDictionary.SortDictionaryValueUsingLinqQueryExpression(dictionary);

        Assert.Same(sortedKeyValuePairs.ElementAt(0).Value, "apple");
        Assert.Same(sortedKeyValuePairs.ElementAt(1).Value, "banana");
        Assert.Same(sortedKeyValuePairs.ElementAt(2).Value, "grape");
        Assert.Same(sortedKeyValuePairs.ElementAt(3).Value, "orange");
    }
}