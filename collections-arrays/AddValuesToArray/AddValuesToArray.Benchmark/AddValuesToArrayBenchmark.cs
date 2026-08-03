using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AddValuesToArray.Benchmark;

[MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class AddValuesToArrayBenchmark
{
    int[] concatArray = Enumerable.Range(0, 10000).ToArray();
    int[] copyToArray = Enumerable.Range(0, 10000).ToArray();
    List<int> list = Enumerable.Range(0, 10000).ToList();

    public IEnumerable<object> ArraySize()
    {
        yield return 10_000;
    }

    [Benchmark, BenchmarkCategory("Manual")]
    [ArgumentsSource(nameof(ArraySize))]
    public void ArrayIndexInitializer(int arraySize)
    {
        AddValuesToArrayMethods.ArrayIndexInitializer(arraySize);
    }

    [Benchmark, BenchmarkCategory("Manual")]
    [ArgumentsSource(nameof(ArraySize))]
    public void SetValueMethod(int arraySize)
    {
        AddValuesToArrayMethods.SetValueMethod(arraySize);
    }

    [Benchmark, BenchmarkCategory("Populated Collection")]
    [ArgumentsSource(nameof(ArraySize))]
    public void ListCollection(int arraySize)
    {
        AddValuesToArrayMethods.UsingList(arraySize, list);
    }

    [Benchmark, BenchmarkCategory("Populated Collection")]
    [ArgumentsSource(nameof(ArraySize))]
    public void LinqConcat(int arraySize)
    {
        AddValuesToArrayMethods.LinqConcat(concatArray);
    }

    [Benchmark, BenchmarkCategory("Populated Collection")]
    [ArgumentsSource(nameof(ArraySize))]
    public void ArrayCopyTo(int arraySize)
    {
        AddValuesToArrayMethods.ArrayCopyTo(arraySize, copyToArray);
    }
}
