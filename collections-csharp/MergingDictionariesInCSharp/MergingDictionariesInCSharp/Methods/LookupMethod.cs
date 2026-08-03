namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static Dictionary<TKey, TValue> LookupMethod<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
        {
            var mergedDictionary = dictionaries.SelectMany(dict => dict)
                                               .ToLookup(pair => pair.Key, pair => pair.Value)
                                               .ToDictionary(group => group.Key, group => group.First());

            return mergedDictionary;
        }
    }
}