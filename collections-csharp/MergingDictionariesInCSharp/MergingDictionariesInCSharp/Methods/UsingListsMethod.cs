namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static Dictionary<TKey, TValue> UsingListsMethod<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
        {
            var keys = new List<TKey>();
            var values = new List<TValue>();

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