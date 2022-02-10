using BenchmarkDotNet.Attributes;
using PopulateArrayWithTheSameValue;

namespace BenchmarkRunner
{
    public class ArrayPopulatorBenchmark
    {
        public static readonly ArrayPopulator _arrayPopulator = new();
        private readonly Article[] benchMarkArray = new Article[1000 * 100];
        private readonly Article benchmarkArticle = new()
            { 
                Title = "How to Copy Array Elements to New Array in C#", 
                LastUpdate = new DateTime(2022, 01, 31) 
            };

        [Benchmark]
        public void FillArray()
        {
            _arrayPopulator.FillArray(benchMarkArray, benchmarkArticle);
        }

        [Benchmark]
        public void EnumerableRepeat()
        {
            _arrayPopulator.EnumerableRepeat(benchmarkArticle, benchMarkArray.Length);
        }

        [Benchmark]
        public void ForStatement()
        {
            _arrayPopulator.ForStatement(benchMarkArray, benchmarkArticle);
        }

        [Benchmark]
        public void ForStatementShallowCopy()
        {
            _arrayPopulator.ForStatementShallowCopy(benchMarkArray, benchmarkArticle);
        }
    }
}
