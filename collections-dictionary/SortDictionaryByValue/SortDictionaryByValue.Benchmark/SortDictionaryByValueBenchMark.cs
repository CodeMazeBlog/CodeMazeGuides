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
    public void SortDictionaryValueUsingLinqOrderBy(DictionaryInput dictionaryInput)
    {
        SortDictionary.SortDictionaryValueUsingLinqOrderBy(dictionaryInput.GeneratedDictionary);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DictionaryInput))]
    public void SortDictionaryValueUsingLinqQueryExpression(DictionaryInput dictionaryInput)
    {
        SortDictionary.SortDictionaryValueUsingLinqQueryExpression(dictionaryInput.GeneratedDictionary);
    }

    [Benchmark]
    [ArgumentsSource(nameof(DictionaryInput))]
    public void SortDictionaryValueUsingSortMethod(DictionaryInput dictionaryInput)
    {
        SortDictionary.SortDictionaryValueUsingSortMethod(dictionaryInput.GeneratedDictionary);
    }
}
