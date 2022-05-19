using BenchmarkDotNet.Attributes;
using PopulateArrayWithTheSameValue;

namespace BenchmarkRunner
{
    public class ArrayPopulatorBenchmark
    {
        private static readonly ArrayPopulator _arrayPopulator = new();
        private readonly Article[] _benchMarkArray = new Article[1000 * 100];
        private readonly Article _benchmarkArticle = new()
        { 
            Title = "How to Copy Array Elements to New Array in C#", 
            LastUpdate = new DateTime(2022, 01, 31) 
        };

        [Benchmark]
        public void FillArray()
        {
            _arrayPopulator.FillArray(_benchMarkArray, _benchmarkArticle);
        }

        [Benchmark]
        public void EnumerableRepeat()
        {
            _arrayPopulator.EnumerableRepeat(_benchmarkArticle, _benchMarkArray.Length);
        }

        [Benchmark]
        public void ForStatement()
        {
            _arrayPopulator.ForStatement(_benchMarkArray, _benchmarkArticle);
        }

        [Benchmark]
        public void ForStatementShallowCopy()
        {
            _arrayPopulator.ForStatementShallowCopy(_benchMarkArray, _benchmarkArticle);
        }
    }
}
