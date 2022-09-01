using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AnyVsCount
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class PerformanceBenchmark { 
    
        private static readonly IEnumerable<int> _numbersEnumerable = GetRandomNumbersBySize(1000);
        private static readonly ICollection<int> _numbersList = GetRandomNumbersBySize(1000).ToList();

        [Benchmark]
        public bool CheckWithAny()
        {
            return _numbersEnumerable.Any();
        }

        [Benchmark]
        public bool CheckWithCount()
        {
            return _numbersEnumerable.Count() > 0;
        }

        [Benchmark]
        public bool CheckWithAnyAndCondition()
        {
            return _numbersEnumerable.Any(num => num > 500);
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


        // Helper methods
        public static IEnumerable<int> GetRandomNumbersBySize(int size)
        {
            var numbers = Enumerable.Range(1, size);
            var rand = new Random();
            var shuffledNumbers =
                numbers.Select(x => new { Number = rand.Next(), Item = x })
                       .OrderBy(x => x.Number)
                       .Select(x => x.Item)
                       .Take(size);

            return shuffledNumbers.ToList();
        }
    }
}
