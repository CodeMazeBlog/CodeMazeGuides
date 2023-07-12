namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static Dictionary<TKey, TValue> UsingHashSetMethod<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
        {
            HashSet<TKey> keys = new HashSet<TKey>();
            HashSet<TValue> values = new HashSet<TValue>();

            foreach (var dictionary in dictionaries)
            {
                foreach (var kvp in dictionary)
                {
                    keys.Add(kvp.Key);
                    values.Add(kvp.Value);
                }
            }

            var mergedDictionary = keys.Zip(values, (key, value) => new KeyValuePair<TKey, TValue>(key, value))
                                       .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return mergedDictionary;
        }
    }
}