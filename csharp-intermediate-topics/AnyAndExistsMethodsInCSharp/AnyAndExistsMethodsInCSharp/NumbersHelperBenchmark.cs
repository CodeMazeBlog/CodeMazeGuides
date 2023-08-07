
using BenchmarkDotNet.Attributes;

namespace AnyAndExistsMethodsInCSharp
{
    public class NumbersHelperBenchmark
    {
        [Params(10000, 100000, 1000000, 10000000)]
        public int ListSize { get; set; }

        private List<int> list;

        [GlobalSetup]
        public void GlobalSetup()
        {
            list = Enumerable.Range(-ListSize, ListSize).ToList();
        }

        [Benchmark]
        public void ComparePositiveNumbersMethods_Any()
        {
            NumbersHelper.CheckIfListContainsPositiveNumbers_Any(list);
        }

        [Benchmark]
        public void ComparePositiveNumbersMethods_Exists()
        {
            NumbersHelper.CheckIfListContainsPositiveNumbers_Exists(list);
        }
    }

}
