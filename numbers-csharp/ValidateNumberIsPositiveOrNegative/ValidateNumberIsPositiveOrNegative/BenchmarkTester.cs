using BenchmarkDotNet.Attributes;

namespace ValidateNumberIsPositiveOrNegative
{
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkTester
    {
        private int[] data;

        [GlobalSetup]
        public void GlobalSetup()
        {
            data = Enumerable.Range(-500, 499).ToArray();
        }

        [Benchmark]
        public void ConditionalMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(data[i]);
            }
        }

        [Benchmark]
        public void LeftShiftMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(data[i]);
            }
        }

        [Benchmark]
        public void RightShiftMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(data[i]);
            }
        }

        [Benchmark]
        public void MathAbsMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(data[i]);
            }
        }

        [Benchmark]
        public void MathSignMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                NumberValidation.IsPositiveOrNegativeUsingMathSignMethod(data[i]);
            }
        }

        [Benchmark]
        public void BuiltInMethod()
        {
            for (int i = 0; i < data.Length; i++)
            {
                NumberValidation.IsPositiveOrNegativeUsingBuiltInMethod(data[i]);
            }
        }
    }
}
