namespace SortDictionaryByValue.Benchmark;
public class DictionaryInput
{
    public DictionaryInput(int count)
    {
        GeneratedDictionary = Generate(count);
    }

    public Dictionary<string, string> GeneratedDictionary { get; set; }

    public Dictionary<string, string> Generate(int count)
    {
        var dictionary = new Dictionary<string, string>();
        for (var i = 0; i < count; i++)
        {
            dictionary.Add($"{i}", Guid.NewGuid().ToString());
        }

        return dictionary;
    }

    public override string ToString() => $"{GeneratedDictionary.Count} items";
}
