using GetDictionaryKeyByValue;

namespace Tests;

public class DictionaryHelperNullTest
{
    private static readonly Dictionary<string, string> _dictionary
        = new(5)
        {
            { "key1", "value1" },
            { "key2", "value2" },
            { "key3", "value3" },
            { "key4", "value4" },
            { "key5", "value5" }
        };

    private readonly DictionaryHelper _dictionaryHelper = new(_dictionary, "NonExistentValue");

    private readonly ReverseDictionaryLookup _reverseDictionaryLookup = new(_dictionary);

    [Fact]
    public void GivenANonExistentValue_WhenUseReverseDictionaryIsCalled_ThenReturnsNull()
    {
        var result = _dictionaryHelper.UseReverseDictionary();

        Assert.Null(result);
    }

    [Fact]
    public void GivenANonExistentValue_WhenUseToLookUpIsCalled_ThenReturnsNull()
    {
        var result = _dictionaryHelper.UseReverseLookup();

        Assert.Null(result);
    }

    [Fact]
    public void GivenANonExistentValue_WhenLoopThroughKeyValuePairsIsCalled_ThenReturnsNull()
    {
        var result = _dictionaryHelper.LoopThroughKeyValuePairs();

        Assert.Null(result);
    }

    [Fact]
    public void GivenANonExistentValue_WhenLoopThroughKeysIsCalled_ThenReturnsNull()
    {
        var result = _dictionaryHelper.LoopThroughKeys();

        Assert.Null(result);
    }

    [Fact]
    public void GivenANonExistentValue_WhenGetKeyFromReverseDictionaryIsCalled_ThenReturnsNull()
    {
        var result = _reverseDictionaryLookup.GetKeyFromReverseDictionary("NonExistentValue");

        Assert.Null(result);
    }

    [Fact]
    public void GivenANonExistentValue_WhenGetKeyFromFrozenReverseDictionaryIsCalled_ThenReturnsNull()
    {
        var result = _reverseDictionaryLookup.GetKeyFromFrozenReverseDictionary("NonExistentValue");

        Assert.Null(result);
    }
}