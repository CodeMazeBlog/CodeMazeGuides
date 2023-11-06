using BenchmarkDotNet.Attributes;

namespace StringTruncationInCSharp
{
    [MemoryDiagnoser]
    public class StringHelperBenchmark
    {
        private readonly int _maxLength = 10;
        private readonly string _originalString = "This is a long string.";
        private static readonly StringHelper _stringHelper = new StringHelper();

        [Benchmark]
        public void TruncateStringUsingSubstring()
        {
            _stringHelper.TruncateStringUsingSubstring(_originalString, _maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingForLoop()
        {
            _stringHelper.TruncateStringUsingForLoop(_originalString, _maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingForLoopWithStringBuilder()
        {
            _stringHelper.TruncateStringUsingForLoopWithStringBuilder(_originalString, _maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingRegularExpressions()
        {
            _stringHelper.TruncateStringUsingRegularExpressions(_originalString, _maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingRemove()
        {
            _stringHelper.TruncateStringUsingRemove(_originalString, _maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingLINQ()
        {
            _stringHelper.TruncateStringUsingLINQ(_originalString, _maxLength);
        }
    }
}