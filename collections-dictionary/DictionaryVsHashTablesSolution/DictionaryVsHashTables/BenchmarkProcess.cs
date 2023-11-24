using BenchmarkDotNet.Attributes;

namespace DictionaryVsHashTables
{
    [MemoryDiagnoser]
    public class BenchmarkProcess
    {
        [Benchmark]
        public void BenchmarkDictionary()
        {
            Utility.ReadDictionary(Utility.CreateSmallNumbersDictionary());
        }

        [Benchmark]
        public void BenchmarkHashtable()
        {
            Utility.ReadHashTable(Utility.CreateSmallNumbersHashTable());
        }

        [Benchmark]
        public void BenchmarkLargeDictionary()
        {
            Utility.ReadDictionary(Utility.CreateLargeDictionary());
        }

        [Benchmark]
        public void BenchmarkLargeHashtable()
        {
            Utility.ReadHashTable(Utility.CreateLargeHashTable());
        }
    }
}