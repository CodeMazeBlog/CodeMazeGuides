namespace GetDictionaryKeyByValue;

public class DictionaryHelper(Dictionary<string, string> dict, string value)
{
    public string? UseReverseDictionary()
    {
        var reverseDict = new Dictionary<string, string>();
        foreach (var keyValuePair in dict)
        {
            reverseDict.TryAdd(keyValuePair.Value, keyValuePair.Key);
        }

        reverseDict.TryGetValue(value, out var key);

        return key;
    }

    public string? UseReverseLookup()
    {
        var reverseLookup = dict.ToLookup(x => x.Value, x => x.Key);

        return reverseLookup[value].FirstOrDefault();
    }

    public string? LoopThroughKeyValuePairs()
    {
        foreach (var keyValuePair in dict)
        {
            if (keyValuePair.Value == value)
            {
                return keyValuePair.Key;
            }
        }

        return default;
    }

    public string? LoopThroughKeys()
    {
        foreach (var key in dict.Keys)
        {
            if (dict[key] == value)
            {
                return key;
            }
        }

        return default;
    }
}