using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AnyVsCount
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class PerformanceBenchmark { 
    
        private static readonly IEnumerable<int> _numbersEnumerable = Enumerable.Range(1, 50000);
        private static readonly ICollection<int> _numbersList = Enumerable.Range(1, 50000).ToList();

        [Benchmark]
        public bool CheckWithAny()
        {
            return _numbersEnumerable.Any();
        }

        [Benchmark]
        public bool CheckWithAnyAndCondition()
        {
            return _numbersEnumerable.Any(num => num > 500);
        }

        [Benchmark]
        public bool CheckWithCount()
        {
            return _numbersEnumerable.Count() > 0;
        }

        [Benchmark]
        public bool CheckWithCountAndCondition()
        {
            return _numbersEnumerable.Count(num => num > 500) > 0;
        }

        [Benchmark]
        public bool CheckWithCountProperty()
        {
            return _numbersList.Count > 0;
        }
    }
}
