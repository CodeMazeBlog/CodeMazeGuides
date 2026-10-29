namespace MergingDictionariesInCSharp
{
    public partial class Methods
    {
        public static Dictionary<TKey, TValue> GroupByMethod<TKey, TValue>(params Dictionary<TKey, TValue>[] dictionaries)
            where TKey : notnull
        {
            var mergedDictionary = dictionaries.SelectMany(dict => dict)
                                               .GroupBy(kvp => kvp.Key)
                                               .ToDictionary(group => group.Key, group => group.First().Value);

            return mergedDictionary;
        }
    }
}