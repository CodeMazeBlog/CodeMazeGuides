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
}