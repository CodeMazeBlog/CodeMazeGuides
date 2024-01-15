using BenchmarkDotNet.Attributes;

namespace StringTruncationInCSharp
{
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Default)]
    public class StringHelperBenchmark
    {
        private readonly string _originalString = new ('a',1_000);

        [Params(10,500,950)] //The test is done for 1%, 50% and 95% of the string length. The string length being 1000.
        public int maxLength;
        
        [Benchmark]
        public void TruncateWithSubstring()
        {
            StringHelper.TruncateWithSubstring(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithForLoop()
        {
            StringHelper.TruncateWithForLoop(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithForLoopStringBuilder()
        {
            StringHelper.TruncateWithForLoopStringBuilder(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithRegularExpressions()
        {
            StringHelper.TruncateWithRegularExpressions(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithRemove()
        {
            StringHelper.TruncateWithRemove(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithLINQ()
        {
            StringHelper.TruncateWithLINQ(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateWithSpan()
        {
            StringHelper.TruncateWithSpan(_originalString, maxLength);
        }
    }
}