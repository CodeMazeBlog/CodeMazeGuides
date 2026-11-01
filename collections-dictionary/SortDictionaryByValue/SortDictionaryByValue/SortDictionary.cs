namespace SortDictionaryByValue;
public class SortDictionary
{
    public static List<KeyValuePair<string, string>> SortDictionaryValueUsingLinqOrderBy(Dictionary<string, string> dictionary)
    {
        var sortedKeyValuePairs = dictionary.OrderBy(x => x.Value).ToList();

        return sortedKeyValuePairs;
    }

    public static List<KeyValuePair<string, string>> SortDictionaryValueUsingLinqQueryExpression(Dictionary<string, string> dictionary)
    {
        var sortedKeyValuePairs = (
            from keyValuePair in dictionary
            orderby keyValuePair.Value ascending
            select keyValuePair
        ).ToList();

        return sortedKeyValuePairs;
    }

    public static List<KeyValuePair<string, string>> SortDictionaryValueUsingSortMethod(Dictionary<string, string> dictionary)
    {
        var sortedKeyValuePairs = dictionary.ToList();
        sortedKeyValuePairs.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

        return sortedKeyValuePairs;
    }

    public static List<KeyValuePair<string, string>> SortDictionaryValueThenKey(Dictionary<string, string> dictionary)
    {
        var sortedKeyValuePairs = dictionary
            .OrderBy(x => x.Value)
            .ThenBy(x => x.Key)
            .ToList();

        return sortedKeyValuePairs;
    }

    public static SortedDictionary<string, int> SortDictionaryKeyUsingSortedDictionary(Dictionary<string, int> stock)
    {
        var sortedStock = new SortedDictionary<string, int>(stock);

        return sortedStock;
    }

    public static OrderedDictionary<string, string> KeepValueOrderInOrderedDictionary(Dictionary<string, string> dictionary)
    {
        var orderedByValue = new OrderedDictionary<string, string>(dictionary.OrderBy(x => x.Value));

        return orderedByValue;
    }
}
