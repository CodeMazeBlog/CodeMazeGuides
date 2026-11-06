using BenchmarkDotNet.Attributes;

namespace SortDictionaryByValue.Benchmark;
public class SortDictionaryByValueBenchMark
{
    public IEnumerable<object> DictionaryInput()
    {
        yield return new DictionaryInput(1000);
        yield return new DictionaryInput(10000);
        yield return new DictionaryInput(100000);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DictionaryInput))]
    public List<KeyValuePair<string, string>> SortDictionaryValueUsingLinqOrderBy(DictionaryInput dictionaryInput)
    {
        return SortDictionary.SortDictionaryValueUsingLinqOrderBy(dictionaryInput.GeneratedDictionary);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DictionaryInput))]
    public List<KeyValuePair<string, string>> SortDictionaryValueUsingLinqQueryExpression(DictionaryInput dictionaryInput)
    {
        return SortDictionary.SortDictionaryValueUsingLinqQueryExpression(dictionaryInput.GeneratedDictionary);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DictionaryInput))]
    public List<KeyValuePair<string, string>> SortDictionaryValueUsingSortMethod(DictionaryInput dictionaryInput)
    {
        return SortDictionary.SortDictionaryValueUsingSortMethod(dictionaryInput.GeneratedDictionary);
    }
}
