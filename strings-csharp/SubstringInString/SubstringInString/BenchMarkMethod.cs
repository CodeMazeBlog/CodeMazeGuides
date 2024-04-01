using BenchmarkDotNet.Attributes;

namespace SubstringInString
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmark
    {
        [Benchmark]
        public void Indexofmethod()
        {
            IndexOfMethod.Indexofmethod();
        }
        [Benchmark]
        public void Substringmethod()
        {
            SubstringMethod.Substringmethod();
        }
        [Benchmark]
        public void Splitmethod()
        {
            SplitMethod.Splitmethod();
        }
        [Benchmark]
        public  void Linqmethod()
        {
            LinqMethod.Linqmethod();
        }
        [Benchmark]
        public void Regexmethod()
        {
           RegexMethod.Regexmethod();
        }

    }
}
