using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace RandomizeGenericListsInCSharp;

[InProcess]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class RandomizeGenericListsBenchmarks
{
    private readonly RandomizeGenericListsMethods _methods = new();
    private List<int> _orderedList = [];
    private List<int> _listToShuffle = [];

    [GlobalSetup]
    public void GlobalSetup()
    {
        _orderedList = _methods.OrderedInts(1_000_000);
    }

    // The in-place shuffles change the list they get, so each iteration starts from a fresh ordered copy.
    [IterationSetup(Targets = [nameof(GenerateRandomLoop), nameof(GenerateRandomShuffle)])]
    public void ResetList()
    {
        _listToShuffle = new List<int>(_orderedList);
    }

    [Benchmark]
    public List<int> GenerateRandomLoop() => _methods.GenerateRandomLoop(_listToShuffle);

    [Benchmark]
    public List<int> GenerateRandomShuffle() => _methods.GenerateRandomShuffle(_listToShuffle);

    [Benchmark]
    public List<int> GenerateLinqShuffle() => _methods.GenerateLinqShuffle(_orderedList);

    [Benchmark]
    public List<int> GenerateRandomOrderBy() => _methods.GenerateRandomOrderBy(_orderedList);

    [Benchmark]
    public List<int> GenerateRandomOrderByGuid() => _methods.GenerateRandomOrderByGuid(_orderedList);
}
