using BenchmarkDotNet.Attributes;

namespace RandomizeGenericListsInCSharp
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class RandomizeGenericListsMethods
    {
        private readonly Random _rand;

        public RandomizeGenericListsMethods() 
        {
            _rand = new Random();
        }
        public IEnumerable<List<int>> SampleList()
        {
            yield return OrderedInts(1000000);
        }

        [ArgumentsSource(nameof(SampleList))]
        [Benchmark]
        public List<int> GenerateRandomLoop(List<int> listToShuffle)
        {
            for (int i = listToShuffle.Count - 1; i > 0; i--)
            {
                var k = _rand.Next(i + 1);
                var value = listToShuffle[k];
                listToShuffle[k] = listToShuffle[i];
                listToShuffle[i] = value;
            }

            return listToShuffle;
        }

        [ArgumentsSource(nameof(SampleList))]
        [Benchmark]
        public List<int> GenerateRandomOrderBy(List<int> listToShuffle)
        {
            var shuffledList = listToShuffle.OrderBy(_ => _rand.Next()).ToList();

            return shuffledList;
        }

        [ArgumentsSource(nameof(SampleList))]
        [Benchmark]
        public List<int> GenerateRandomOrderByGuid(List<int> listToShuffle)
        {
            var shuffledList = listToShuffle.OrderBy(_ => Guid.NewGuid()).ToList();

            return shuffledList;
        }

        public List<int> OrderedInts(int size)
        {
            var numbers = new List<int>();

            for (int i = 0; i < size; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }
    }
}