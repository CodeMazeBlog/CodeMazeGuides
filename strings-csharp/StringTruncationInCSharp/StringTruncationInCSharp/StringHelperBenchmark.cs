using BenchmarkDotNet.Attributes;

namespace StringTruncationInCSharp
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class StringHelperBenchmark
    {
        private string _originalString = new string('a',1_000);
        private static readonly StringHelper _stringHelper = new StringHelper();

        [Params(10,500,950)] //The test is done for 1%, 50% and 95% of the string length. The string length being 1000.
        public int maxLength;
        
        [Benchmark]
        public void TruncateWithSubstring()
        {
            _stringHelper.TruncateWithSubstring(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithForLoop()
        {
            _stringHelper.TruncateWithForLoop(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithForLoopStringBuilder()
        {
            _stringHelper.TruncateWithForLoopStringBuilder(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithRegularExpressions()
        {
            _stringHelper.TruncateWithRegularExpressions(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithRemove()
        {
            _stringHelper.TruncateWithRemove(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithLINQ()
        {
            _stringHelper.TruncateWithLINQ(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithSpan()
        {
            _stringHelper.TruncateWithSpan(_originalString, maxLength);
        }
    }
}