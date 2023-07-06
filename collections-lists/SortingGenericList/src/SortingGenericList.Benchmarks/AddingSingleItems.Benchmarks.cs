namespace SortingGenericList.Benchmarks;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class AddingSingleItemsBenchmark
{
    private const int BenchmarkArraySize = 128;
    private readonly Product[] _valuesToAdd = BenchmarkSetupHelpers.GenerateProducts(BenchmarkArraySize);

    [Benchmark(Description = "List: AddAllThenSort")]
    public IList<Product> AddSingleItemsAndThenSortInPlace()
    {
        var list = new List<Product>();
        foreach (var item in _valuesToAdd) list.Add(item);
        ListSortMethods.SortListInPlaceWithSort(list);

        return list;
    }

    [Benchmark(Description = "List: InsertSingleSorted")]
    public IList<Product> AddSingleItemsInSortedOrder()
    {
        var list = new List<Product>();
        foreach (var item in _valuesToAdd)
        {
            var index = list.BinarySearch(item);
            if (index < 0) index = ~index;
            list.Insert(index, item);
        }

        return list;
    }

    [Benchmark(Description = "List: AddSingleAndSort")]
    public IList<Product> AddSingleItemsAndSortInPlace()
    {
        var list = new List<Product>();
        foreach (var item in _valuesToAdd)
        {
            list.Add(item);
            ListSortMethods.SortListInPlaceWithSort(list);
        }

        return list;
    }

    [Benchmark(Description = "MySortedList: AddSingle")]
    public IList<Product> MySortedList_AddSingleItems()
    {
        var list = new MySortedList<Product>();
        foreach (var item in _valuesToAdd) list.Add(item);

        return list;
    }

    [Benchmark(Description = "List: AddAllUseLinqOrder")]
    public IList<Product> AddSingleItemsSortWithOrder()
    {
        var list = new List<Product>();
        foreach (var item in _valuesToAdd) list.Add(item);

        return ListSortMethods.SortListWithOrder(list).ToList();
    }

    [Benchmark(Description = "List: AddAllUseLinqOrderBy")]
    public IList<Product> AddSingleItemsSortWithOrderBy()
    {
        var list = new List<Product>();
        foreach (var item in _valuesToAdd) list.Add(item);

        return ListSortMethods.SortListWithOrderBy(list, x => x.ProductName).ToList();
    }
}