namespace CompareTwoDictionaries;

public class DictionaryComparisonHelper(Dictionary<int, string> Dict1, Dictionary<int, string> Dict2)
{
    private bool AreKeysAndCountNotEqual()
        => Dict1.Count != Dict2.Count
        || Dict1.Keys.Except(Dict2.Keys).Any()
        || Dict2.Keys.Except(Dict1.Keys).Any();

    public bool UseSequenceEqual()
    {
        if (AreKeysAndCountNotEqual()) return false;

        return Dict1.OrderBy(kvp => kvp.Key).SequenceEqual(Dict2.OrderBy(kvp => kvp.Key));
    }

    public bool UseEnumerableAll()
    {
        if (AreKeysAndCountNotEqual()) return false;

        return Dict1.Keys.All(k => Dict2.ContainsKey(k) && Dict2[k] == Dict1[k]);
    }

    public bool UseForeachLoop()
    {
        if (AreKeysAndCountNotEqual()) return false;

        foreach (var kvp in Dict1)
        {
            if (!Dict2.TryGetValue(kvp.Key, out var value) || value != kvp.Value)
            {
                return false;
            }
        }

        return true;
    }
}