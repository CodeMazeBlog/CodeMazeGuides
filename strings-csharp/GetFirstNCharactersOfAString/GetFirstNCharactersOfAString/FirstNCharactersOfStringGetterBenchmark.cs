using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace GetFirstNCharactersOfAString
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class FirstNCharactersOfStringGetterBenchmark
    {
        private readonly FirstNCharactersOfStringGetter _firstNCharactersOfStringGetter;

        public FirstNCharactersOfStringGetterBenchmark()
        {
            _firstNCharactersOfStringGetter
                = new FirstNCharactersOfStringGetter();
        }

        [Benchmark]
        public void UseRemove()
            => _firstNCharactersOfStringGetter.UseRemove();

        [Benchmark]
        public void UseLINQ()
            => _firstNCharactersOfStringGetter.UseLINQ();

        [Benchmark]
        public void UseRangeOperator()
            => _firstNCharactersOfStringGetter.UseRangeOperator();

        [Benchmark]
        public void UseAsSpan()
            => _firstNCharactersOfStringGetter.UseAsSpan();

        [Benchmark]
        public void UseToCharArray()
            => _firstNCharactersOfStringGetter.UseToCharArray();

        [Benchmark]
        public void UsePadRight()
            => _firstNCharactersOfStringGetter.UsePadRight();
    }
}