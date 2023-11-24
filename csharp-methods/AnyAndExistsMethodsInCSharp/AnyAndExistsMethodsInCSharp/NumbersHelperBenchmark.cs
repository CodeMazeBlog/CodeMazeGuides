using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AnyAndExistsMethodsInCSharp
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class NumbersHelperBenchmark
    {
        [Params(10000, 100000, 1000000)]
        public int ListSize { get; set; }

        private List<int> list;

        [GlobalSetup]
        public void GlobalSetup()
        {
            list = Enumerable.Range(-ListSize, ListSize).ToList();
        }

        [Benchmark]
        public void ComparePositiveNumbersMethodsExists()
        {
            NumbersHelper.CheckIfListContainsPositiveNumbersExists(list);
        }

        [Benchmark]
        public void ComparePositiveNumbersMethodsAny()
        {
            NumbersHelper.CheckIfListContainsPositiveNumbersAny(list);
        }
    }

}
