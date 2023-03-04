using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkRunner 
{

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DeleteElementsFromAnArrayBenchmark 
    {
        private int[] _myArray = FillArray();

        private readonly int _key = 7;

        [Benchmark]
        public int[] DeleteWithFindAll() 
        {
            return Array.FindAll(_myArray, i => i != _key);
        }

        [Benchmark]
        public int[] DeleteWithRemoveAll() 
        {
            var list = new List<int>(_myArray);
            list.RemoveAll(e => e == _key);

            return list.ToArray();
        }

        [Benchmark]
        public int[] DeleteWithWhere() 
        {
            return _myArray.Where(e => e != _key).ToArray();
        }
        
        [Benchmark]
        public int[] DeleteWithLoop() 
        {
            var newSize = 0;

            for (int i = 0; i < _myArray.Length; i++) 
            {
                if (_myArray[i] != _key) 
                {
                    _myArray[newSize] = _myArray[i];
                    newSize++;
                }
            }

            Array.Resize(ref _myArray, newSize);

            return _myArray;
        }
        
        private static int[] FillArray() 
        {
            var rnd = new Random();
            var myArray = new int[1000];

            for (int i = 0; i < 1000; i++) 
            {
                myArray[i] = rnd.Next(1, 10);
            }

            return myArray;
        }
    }
}