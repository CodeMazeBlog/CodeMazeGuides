namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static Dictionary<TKey, TValue> ConcatMethod<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
        {
            var mergedDictionary = dictionaries.Aggregate((dict1, dict2) =>
                    dict1.Concat(dict2).ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                );

            return mergedDictionary;
        }
    }
}