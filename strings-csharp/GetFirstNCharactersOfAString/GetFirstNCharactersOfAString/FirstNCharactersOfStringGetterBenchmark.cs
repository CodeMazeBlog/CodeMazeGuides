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
        public void UseForLoop()
            => _firstNCharactersOfStringGetter.UseForLoop();

        [Benchmark]
        public void UseRemove()
            => _firstNCharactersOfStringGetter.UseRemove();

        [Benchmark]
        public void UseLINQ()
            => _firstNCharactersOfStringGetter.UseLINQ();

        [Benchmark]
        public void UseAsSpan()
            => _firstNCharactersOfStringGetter.UseAsSpan();

        [Benchmark]
        public void UseAsSpanWithRangeOperator()
            => _firstNCharactersOfStringGetter.UseAsSpanWithRangeOperator();

        [Benchmark]
        public void UseReadOnlyMemory()
            => _firstNCharactersOfStringGetter.UseReadOnlyMemory();

        [Benchmark]
        public void UseToCharArray()
            => _firstNCharactersOfStringGetter.UseToCharArray();
    }
}