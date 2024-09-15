namespace CompareTwoDictionaries;

public class DictionaryEqualityComparer
{
    public static bool UseSequenceEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        where TKey : notnull, IEquatable<TKey> where TValue : IEquatable<TValue>
    {
        if (dict1.Count != dict2.Count) return false;

        return dict1.OrderBy(kvp => kvp.Key).SequenceEqual(dict2.OrderBy(kvp => kvp.Key));
    }

    public static bool UseEnumerableAll<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        where TKey : notnull where TValue : IEquatable<TValue>
    {
        if (dict1.Count != dict2.Count) return false;

        return dict1.All(kvp => dict2.TryGetValue(kvp.Key, out var value) && value.Equals(kvp.Value));
    }

    public static bool UseForeachLoop<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        where TKey : notnull where TValue : IEquatable<TValue>
    {
        if (dict1.Count != dict2.Count) return false;

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