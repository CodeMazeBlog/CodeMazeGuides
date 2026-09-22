using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AddValuesToArray.Benchmark;

[MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[HideColumns("StdDev", "Median", "Gen0", "Gen1")]
public class AddValuesToArrayBenchmark
{
    private int[] _source = [];
    private List<int> _list = [];

    [Params(1_000, 10_000)]
    public int ArraySize { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _source = Enumerable.Range(0, ArraySize).ToArray();
        _list = Enumerable.Range(0, ArraySize).ToList();
    }

    [Benchmark, BenchmarkCategory("Manual")]
    public int[] ArrayIndexInitializer() => AddValuesToArrayMethods.ArrayIndexInitializer(ArraySize);

    [Benchmark, BenchmarkCategory("Manual")]
    public int[] SetValueMethod() => AddValuesToArrayMethods.SetValueMethod(ArraySize);

    [Benchmark, BenchmarkCategory("Populated Collection")]
    public int[] ListCollection() => AddValuesToArrayMethods.UsingList(_list);

    [Benchmark, BenchmarkCategory("Populated Collection")]
    public int[] LinqConcat() => AddValuesToArrayMethods.LinqConcat(_source);

    [Benchmark, BenchmarkCategory("Populated Collection")]
    public int[] ArrayCopyTo() => AddValuesToArrayMethods.ArrayCopyTo(ArraySize, _source);

    [Benchmark, BenchmarkCategory("Populated Collection")]
    public int[] CollectionExpression() => AddValuesToArrayMethods.CollectionExpression(_source);
}
