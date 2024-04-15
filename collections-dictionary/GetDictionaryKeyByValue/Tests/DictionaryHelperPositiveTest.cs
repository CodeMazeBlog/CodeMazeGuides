using GetDictionaryKeyByValue;
namespace Tests;

public class DictionaryHelperPositiveTest
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

    private readonly DictionaryHelper _dictionaryHelper = new(_dictionary, "value3");

    private static readonly string _expectedKey = "key3";

    [Fact]
    public void GivenAnExistentValue_WhenUseReverseDictionaryIsCalled_ThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.UseReverseDictionary();

        Assert.Equal(_expectedKey, result);
    }

    [Fact]
    public void GivenAnExistentValue_WhenUseToLookUpIsCalled_ThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.UseReverseLookup();

        Assert.Equal(_expectedKey, result);
    }

    [Fact]
    public void GivenAnExistentValue_WhenLoopThroughKeyValuePairsIsCalled_ThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.LoopThroughKeyValuePairs();

        Assert.Equal(_expectedKey, result);
    }

    [Fact]
    public void GivenAnExistentValue_WhenLoopThroughKeysIsCalled_ThenReturnsTheDesiredKey()
    {
        var result = _dictionaryHelper.LoopThroughKeys();

        Assert.Equal(_expectedKey, result);
    }
}