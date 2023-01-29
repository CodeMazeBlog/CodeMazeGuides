using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkRunner
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DefaultValueFromDictionaryInCSharpBenchmark
    {
        private Dictionary<string, int> myDictionary = fillDictionary();

        public static Dictionary<string, int> fillDictionary()
        {
            var myDictionary = new Dictionary<string, int>();

            for (int i = 1; i < 10000; i++)
            {
                myDictionary.Add($"number_{i}", i);
            }
            return myDictionary;
        }

        private readonly string key = "number_1000";

        [Benchmark]
        public int ContainsKey()
        {
            return myDictionary.ContainsKey(key) ? myDictionary[key] : default;
        }


        [Benchmark]
        public int TryGetValue()
        {
            return myDictionary.TryGetValue(key, out var value) ? value : default;
        }

        [Benchmark]
        public int GetValueOrDefault()
        {
            return myDictionary.GetValueOrDefault(key);
        }
    }
}