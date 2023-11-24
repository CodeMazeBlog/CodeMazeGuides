using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkRunner
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DefaultValueFromDictionaryInCSharpBenchmark
    {
        private Dictionary<string, int> _myDictionary = FillDictionary();

        private readonly string _key = "number_1000";

        [Benchmark]
        public int ContainsKey()
        {
            return _myDictionary.ContainsKey(_key) ? _myDictionary[_key] : default;
        }

        [Benchmark]
        public int TryGetValue()
        {
            return _myDictionary.TryGetValue(_key, out var value) ? value : default;
        }

        [Benchmark]
        public int GetValueOrDefault()
        {
            return _myDictionary.GetValueOrDefault(_key);
        }

        private static Dictionary<string, int> FillDictionary()
        {
            var myDictionary = new Dictionary<string, int>();

            for (int i = 1; i < 10000; i++)
            {
                myDictionary.Add($"number_{i}", i);
            }
            return myDictionary;
        }
    }
}