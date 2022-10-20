using BenchmarkDotNet.Attributes;

namespace DictionaryVsHashTables
{
    public class BenchmarkProcess
    {
        [Benchmark]
        public void BenchmarkADictionary()
        {
            Utility.ReadADictionary(Utility.CreateASmallNumbersDictionary());
        }

        [Benchmark]
        public void BenchmarkAHashtable()
        {
            Utility.ReadAHashTable(Utility.CreateASmallNumbersHashTable());
        }

        [Benchmark]
        public void BenchmarkALargeDictionary()
        {
            Utility.ReadADictionary(Utility.CreateALargeDictionary());
        }

        [Benchmark]
        public void BenchmarkALargeHashtable()
        {
            Utility.ReadAHashTable(Utility.CreateALargeHashTable());
        }
    }
}