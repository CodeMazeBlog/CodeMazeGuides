using BenchmarkDotNet.Attributes;

namespace StringTruncationInCSharp
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class StringHelperBenchmark
    {
        private string _originalString = "This is a long string.";
        private static readonly StringHelper _stringHelper = new StringHelper();

        [Params(0.01, 0.10, 0.50, 0.95)]
        public double MaxLengthPercentage;
    
        [GlobalSetup]
        public void Setup()
        {
            _originalString = GetDummyStringToTestBenchmark();
        }


        [Benchmark]
        public void TruncateStringUsingSubstring()
        {
            int maxLength = (int)(_originalString.Length * MaxLengthPercentage);

            _stringHelper.TruncateStringUsingSubstring(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingForLoop()
        {
            int maxLength = (int)(_originalString.Length * MaxLengthPercentage);

            _stringHelper.TruncateStringUsingForLoop(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingForLoopWithStringBuilder()
        {
            int maxLength = (int)(_originalString.Length * MaxLengthPercentage);
            _stringHelper.TruncateStringUsingForLoopWithStringBuilder(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingRegularExpressions()
        {
            int maxLength = (int)(_originalString.Length * MaxLengthPercentage);
            _stringHelper.TruncateStringUsingRegularExpressions(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingRemove()
        {
            int maxLength = (int)(_originalString.Length * MaxLengthPercentage);

            _stringHelper.TruncateStringUsingRemove(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingLINQ()
        {
            int maxLength = (int)(_originalString.Length * MaxLengthPercentage);

            _stringHelper.TruncateStringUsingLINQ(_originalString, maxLength);
        }

        [Benchmark]
        public void TruncateStringUsingSpan()
        {
            int maxLength = (int)(_originalString.Length * MaxLengthPercentage);

            _stringHelper.TruncateStringUsingSpan(_originalString, maxLength);
        }

        private string GetDummyStringToTestBenchmark()
        {
            return "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. N";
        }
    }
}