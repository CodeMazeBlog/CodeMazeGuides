using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace HashSetvsSortedSetInCSharp
{
    [MemoryDiagnoser]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Operations
    {
        private readonly List<int> _numList;
        private readonly HashSet<int> _hashSet;
        private readonly SortedSet<int> _sortedSet;
        private readonly int _searchValue;

        public Operations()
        {
            _numList = RandomInts(1000000);
            _hashSet = InitializeIntHashSet();
            _sortedSet = InitializeIntSortedSet();
            _searchValue = Int32.MaxValue - 1;
        }

        [Benchmark]
        public HashSet<int> InitializeIntHashSet() 
        {
            var hashSet = new HashSet<int>();

            foreach (var number in _numList) 
            {
                hashSet.Add(number);
            }

            return hashSet;
        }

        [Benchmark]
        public SortedSet<int> InitializeIntSortedSet()
        {
            var sortedSet = new SortedSet<int>();

            foreach (var number in _numList)
            {
                sortedSet.Add(number);
            }

            return sortedSet;
        }

        [Benchmark]
        public HashSet<int> RemoveElementFromHashSet()
        {
            _hashSet.Remove(_searchValue);

            return _hashSet;
        }

        [Benchmark]
        public HashSet<int> RemoveWhereFromHashSet()
        {
            _hashSet.RemoveWhere(IsOdd);

            return _hashSet;
        }

        [Benchmark]
        public SortedSet<int> RemoveElementFromSortedSet()
        {
            _sortedSet.Remove(_searchValue);

            return _sortedSet;
        }

        [Benchmark]
        public SortedSet<int> RemoveWhereFromSortedSet()
        {
            _sortedSet.RemoveWhere(IsOdd);

            return _sortedSet;
        }

        [Benchmark]
        public bool SearchSortedSet()
        {
            return _sortedSet.Contains(_searchValue);
        }

        [Benchmark]
        public bool SearchHashSet()
        {
            return _hashSet.Contains(_searchValue);
        }

        [Benchmark]
        public List<int> SortHashSetElements()
        {
            var sortElements = _hashSet.OrderBy(element => element).ToList();
   
            return sortElements;
        }

        [Benchmark]
        public List<int> SortSortedSetElements()
        {
            return _sortedSet.ToList();
        }

        private List<int> RandomInts(int size)
        {
            var rand = new Random();
            var numbers = new List<int>();

            for (int i = 0; i < size - 1; i++)
            {
                numbers.Add(rand.Next());
            }

            numbers.Add(Int32.MaxValue - 1);

            return numbers;
        }

        private bool IsOdd(int num)
        {
            return num % 2 == 1;
        }
    }
}
