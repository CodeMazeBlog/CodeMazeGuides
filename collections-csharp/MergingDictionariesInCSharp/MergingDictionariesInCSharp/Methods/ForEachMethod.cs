namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static Dictionary<TKey, TValue> ForEachMethod<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
        {
            var mergedDictionary = new Dictionary<TKey, TValue>();

            foreach (var dictionary in dictionaries)
            {
                foreach (var kvp in dictionary)
                {
                    if (!mergedDictionary.ContainsKey(kvp.Key))
                    {
                        mergedDictionary[kvp.Key] = kvp.Value;
                    }
                }
            }

            return mergedDictionary;
        }
    }
}