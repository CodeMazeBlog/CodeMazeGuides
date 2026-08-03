using BenchmarkDotNet.Running;
using CompareTwoDictionaries;

Dictionary<int, string> dict1
    = new()
    {
        {1, "Rosary Ogechi"},
        {2, "Clare Chiamaka"},
    };

Dictionary<int, string> dict2
    = new()
    {
        {1, "Rosary Ogechi"},
        {2, "Clare Chiamaka"},
    };

DictionaryEqualityComparer.UseForeachLoop(dict1, dict2);

BenchmarkRunner.Run<DictionaryEqualityComparerBenchmark>();