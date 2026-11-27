global using Xunit;
using SortDictionaryByValue;

namespace SortDictionaryByValueTests;

public class SortDictionaryByValueUnitTest
{
    private static Dictionary<string, string> CreateDictionary() => new()
    {
        { "1", "apple" },
        { "2", "orange" },
        { "3", "banana" },
        { "4", "grape" }
    };

    private static readonly string[] ExpectedValues = ["apple", "banana", "grape", "orange"];

    [Fact]
    public void GivenUnorderedDictionary_WhenSortedUsingLinqOrderBy_ThenReturnOrderedKeyValuePairs()
    {
        var sortedKeyValuePairs = SortDictionary.SortDictionaryValueUsingLinqOrderBy(CreateDictionary());

        Assert.Equal(ExpectedValues, sortedKeyValuePairs.Select(x => x.Value));
    }

    [Fact]
    public void GivenUnorderedDictionary_WhenSortedUsingSortMethod_ThenReturnOrderedKeyValuePairs()
    {
        var sortedKeyValuePairs = SortDictionary.SortDictionaryValueUsingSortMethod(CreateDictionary());

        Assert.Equal(ExpectedValues, sortedKeyValuePairs.Select(x => x.Value));
    }

    [Fact]
    public void GivenUnorderedDictionary_WhenSortedUsingLinqQueryExpression_ThenReturnOrderedKeyValuePairs()
    {
        var sortedKeyValuePairs = SortDictionary.SortDictionaryValueUsingLinqQueryExpression(CreateDictionary());

        Assert.Equal(ExpectedValues, sortedKeyValuePairs.Select(x => x.Value));
    }

    [Fact]
    public void GivenDuplicateValues_WhenSortedByValueThenKey_ThenTiesAreOrderedByKey()
    {
        var dictionary = new Dictionary<string, string>
        {
            { "2", "apple" },
            { "1", "apple" },
            { "3", "banana" }
        };

        var sortedKeyValuePairs = SortDictionary.SortDictionaryValueThenKey(dictionary);

        Assert.Equal(["1", "2", "3"], sortedKeyValuePairs.Select(x => x.Key));
    }

    [Fact]
    public void GivenUnorderedKeys_WhenLoadedIntoSortedDictionary_ThenEnumeratesByKey()
    {
        var stock = new Dictionary<string, int>
        {
            { "orange", 12 },
            { "apple", 7 },
            { "banana", 30 }
        };

        var sortedStock = SortDictionary.SortDictionaryKeyUsingSortedDictionary(stock);

        Assert.Equal(["apple", "banana", "orange"], sortedStock.Keys);
    }

    [Fact]
    public void GivenUnorderedDictionary_WhenSortedIntoOrderedDictionary_ThenKeepsValueOrder()
    {
        var orderedByValue = SortDictionary.KeepValueOrderInOrderedDictionary(CreateDictionary());

        Assert.Equal(ExpectedValues, orderedByValue.Values);
        Assert.Equal("banana", orderedByValue.GetAt(1).Value);
    }
}
