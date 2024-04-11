using GetDictionaryKeyByValue;
namespace Tests;

public class DictionaryHelperTest
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
    private static readonly string _value = "value3";

    private readonly DictionaryHelper _dictionaryHelper = new(_dictionary, _value);

    private static readonly string _expectedKey = "key3";

    [Fact]
    public void WhenUseReverseDictionaryIsCalledThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.UseReverseDictionary();

        Assert.Equal(_expectedKey, result);
    }

    [Fact]
    public void WhenUseToLookUpIsCalledThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.UseToLookup();

        Assert.Equal(_expectedKey, result);
    }

    [Fact]
    public void WhenLoopThroughKeyValuePairsIsCalledThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.LoopThroughKeyValuePairs();

        Assert.Equal(_expectedKey, result);
    }

    [Fact]
    public void WhenLoopThroughKeysIsCalledThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.LoopThroughKeys();

        Assert.Equal(_expectedKey, result);
    }
}