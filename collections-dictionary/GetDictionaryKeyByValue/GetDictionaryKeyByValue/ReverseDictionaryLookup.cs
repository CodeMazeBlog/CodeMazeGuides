using System.Collections.Frozen;

namespace GetDictionaryKeyByValue;

public class ReverseDictionaryLookup(Dictionary<string, string> dict)
{
    private readonly Dictionary<string, string> _reverseDict = BuildReverseDictionary(dict);

    private readonly FrozenDictionary<string, string> _frozenReverseDict
        = BuildReverseDictionary(dict).ToFrozenDictionary();

    public string? GetKeyFromReverseDictionary(string value)
    {
        _reverseDict.TryGetValue(value, out var key);

        return key;
    }

    public string? GetKeyFromFrozenReverseDictionary(string value)
    {
        _frozenReverseDict.TryGetValue(value, out var key);

        return key;
    }

    private static Dictionary<string, string> BuildReverseDictionary(Dictionary<string, string> dict)
    {
        var reverseDict = new Dictionary<string, string>(dict.Count);
        foreach (var keyValuePair in dict)
        {
            reverseDict.TryAdd(keyValuePair.Value, keyValuePair.Key);
        }

        return reverseDict;
    }
}