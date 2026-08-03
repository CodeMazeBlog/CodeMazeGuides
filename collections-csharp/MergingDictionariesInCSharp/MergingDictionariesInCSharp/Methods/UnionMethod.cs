namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static Dictionary<TKey, TValue> UnionMethod<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
        {
            var mergedDictionary = dictionaries.Aggregate((result, dict) =>
            {
                return result.Union(dict).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            });

            return mergedDictionary;
        }
    }
}