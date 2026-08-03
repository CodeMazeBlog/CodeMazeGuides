using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace CheckIfStringArrayContainsAValueAndGetIndex
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class CheckMethodsBenchMark
    {
        private readonly string[] _stringArray = GenerateBenchMarkArray.CreateArray();
        private const string Value = "jane doe";

        [Benchmark]
        public int ForLoop()
        {
            int index = -1;
            for (int i = 0; i < _stringArray.Length; i++)
            {
                if (_stringArray[i] == Value)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        [Benchmark]
        public int ForEachLoop()
        {
            int index = -1;
            int step = 0;
            foreach (var item in _stringArray)
            {
                if (item == Value)
                {
                    index = step;
                    break;
                }
                step++;
            }

            return index;
        }

        [Benchmark]
        public int ArrayIndexOf()
        {
            int index = Array.IndexOf(_stringArray, Value);

            return index;
        }

        [Benchmark]
        public int ArrayFindIndex()
        {
            int index = Array.FindIndex(_stringArray, str => str == Value);

            return index;
        }
    }
}