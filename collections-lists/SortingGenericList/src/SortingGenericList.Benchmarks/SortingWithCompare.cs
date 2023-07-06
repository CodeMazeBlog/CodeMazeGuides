namespace SortingGenericList.Benchmarks;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class SortingWithCompare
{
    private const int BenchmarkArraySize = 128;
    private readonly Product[] _valuesToAdd = BenchmarkSetupHelpers.GenerateProducts(BenchmarkArraySize);

    [Benchmark(Description = "List: AddRangeThenSort")]
    public IList<Product> ListAddRangeThenSort()
    {
        var list = new List<Product>(_valuesToAdd.Length);
        list.AddRange(_valuesToAdd);
        list.Sort();

        return list;
    }

    [Benchmark(Description = "List: AddRangeThenSortCustom")]
    public IList<Product> ListAddRangeThenSortWithCustomCompare()
    {
        var list = new List<Product>(_valuesToAdd.Length);
        list.AddRange(_valuesToAdd);
        list.Sort(new DescendingProductComparer());

        return list;
    }

    [Benchmark(Description = "MySortedList: AddRange")]
    public IList<Product> MySortedListAddRange()
    {
        var list = new MySortedList<Product>(_valuesToAdd.Length);
        list.AddRange(_valuesToAdd);

        return list;
    }

    [Benchmark(Description = "MySortedList: AddRangeCustomCompare")]
    public IList<Product> MySortedListAddRangeWithCustomCompare()
    {
        var list = new MySortedList<Product>(_valuesToAdd.Length, new DescendingProductComparer());
        list.AddRange(_valuesToAdd);

        return list;
    }
}
