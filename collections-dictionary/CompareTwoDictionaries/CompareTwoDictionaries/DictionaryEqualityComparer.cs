namespace CompareTwoDictionaries;

public class DictionaryEqualityComparer
{
    public static bool AreKeysAndCountNotEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        where TKey : notnull
    {
        return dict1.Count != dict2.Count || dict1.Keys.Except(dict2.Keys).Any() || dict2.Keys.Except(dict1.Keys).Any();
    }

    public static bool UseSequenceEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        where TKey : notnull where TValue : IEquatable<TValue>
    {
        if (AreKeysAndCountNotEqual(dict1, dict2)) return false;

        return dict1.OrderBy(kvp => kvp.Key).SequenceEqual(dict2.OrderBy(kvp => kvp.Key));
    }

    public static bool UseEnumerableAll<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        where TKey : notnull where TValue : IEquatable<TValue>
    {
        if (AreKeysAndCountNotEqual(dict1, dict2)) return false;

        return dict1.Keys.All(k => dict2.ContainsKey(k) && dict2[k].Equals(dict1[k]));
    }

    public static bool UseForeachLoop<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        where TKey : notnull where TValue : IEquatable<TValue>
    {
        if (AreKeysAndCountNotEqual(dict1, dict2)) return false;

        foreach (var kvp in dict1)
        {
            if (!dict2.TryGetValue(kvp.Key, out var value) || !value.Equals(kvp.Value))
            {
                return false;
            }
        }

        return true;
    }
}