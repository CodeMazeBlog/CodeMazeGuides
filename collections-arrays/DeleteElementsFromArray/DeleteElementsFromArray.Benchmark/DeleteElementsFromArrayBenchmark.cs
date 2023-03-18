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
        public int[] DeleteWithArrayCopy() 
        {
            var indexToRemove = Array.IndexOf(_myArray, _key);

            if (indexToRemove < 0) 
            {
                return _myArray;
            }

            var newArray = new int[_myArray.Length - 1];

            Array.Copy(_myArray, 0, newArray, 0, indexToRemove);

            Array.Copy(_myArray, indexToRemove + 1, newArray, indexToRemove, _myArray.Length - indexToRemove - 1);

            return newArray;
        }

        [Benchmark]
        public int[] DeleteWithArraySegment() 
        {
            var indexToRemove = Array.IndexOf(_myArray, _key);

            if (indexToRemove >= 0) 
            {
                var segment1 = new ArraySegment<int>(_myArray, 0, indexToRemove);
                var segment2 = new ArraySegment<int>(_myArray, indexToRemove + 1, _myArray.Length - indexToRemove - 1);
                _myArray = segment1.Concat(segment2).ToArray();
            }

            return _myArray;
        }

        [Benchmark]
        public int[] DeleteWithLoop() 
        {
            var indexToRemove = Array.IndexOf(_myArray, _key);

            if (indexToRemove >= 0) 
            {
                var tempArray = new int[_myArray.Length - 1];
                for (int i = 0, j = 0; i < _myArray.Length; i++) 
                {
                    if (i == indexToRemove) 
                    {
                        continue;
                    }
                    tempArray[j] = _myArray[i];
                    j++;
                }

                return tempArray;
            }

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