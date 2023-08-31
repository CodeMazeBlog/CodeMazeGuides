using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Buffers;

namespace BenchmarkRunner
{

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DeleteElementsFromAnArrayBenchmark
    {
        private readonly int[] _myArray = FillArray();

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
        public int[] DeleteWithList()
        {
            var indexToRemove = Array.IndexOf(_myArray, _key);

            if (indexToRemove < 0)
            {
                return _myArray;
            }

            var list = new List<int>(_myArray.Length);

            for (int i = 0; i < _myArray.Length; i++)
            {
                if (_myArray[i] != _key)
                {
                    list.Add(_myArray[i]);
                }
            }

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

            var tempArray = new int[_myArray.Length - 1];

            Array.Copy(_myArray, 0, tempArray, 0, indexToRemove);

            Array.Copy(_myArray, indexToRemove + 1, tempArray, indexToRemove, _myArray.Length - indexToRemove - 1);

            return tempArray;
        }

        [Benchmark]
        public int[] DeleteWithBufferCopy()
        {
            var indexToRemove = Array.IndexOf(_myArray, _key);

            if (indexToRemove < 0)
            {
                return _myArray;
            }

            var tempArray = new int[_myArray.Length - 1];

            Buffer.BlockCopy(_myArray, 0, tempArray, 0, indexToRemove * 4);

            Buffer.BlockCopy(_myArray, (indexToRemove + 1) * 4, tempArray, indexToRemove * 4, (_myArray.Length - indexToRemove - 1) * 4);

            return tempArray;
        }

        [Benchmark]
        public int[] DeleteWithArraySegment()
        {
            var indexToRemove = Array.IndexOf(_myArray, _key);

            if (indexToRemove < 0)
            {
                return _myArray;
            }

            int[] tempArray;

            var segment1 = new ArraySegment<int>(_myArray, 0, indexToRemove);

            var segment2 = new ArraySegment<int>(_myArray, indexToRemove + 1, _myArray.Length - indexToRemove - 1);

            tempArray = segment1.Concat(segment2).ToArray();

            return tempArray;
        }

        [Benchmark]
        public int[] DeleteWithLoop()
        {
            var indexToRemove = Array.IndexOf(_myArray, _key);

            if (indexToRemove < 0)
            {
                return _myArray;
            }

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

        [Benchmark]
        public int[] DeleteWithPooledArray()
        {
            var tempArray = ArrayPool<int>.Shared.Rent(_myArray.Length);
            try
            {
                var tempSpan = tempArray.AsSpan();
                var index = 0;
                foreach (var element in _myArray.AsSpan())
                {
                    if (element != _key) tempSpan[index++] = element;
                }

                return tempSpan[0..index].ToArray();
            }
            finally
            {
                ArrayPool<int>.Shared.Return(tempArray);
            }
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