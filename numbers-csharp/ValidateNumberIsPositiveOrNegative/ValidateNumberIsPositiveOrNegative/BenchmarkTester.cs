using BenchmarkDotNet.Attributes;

namespace ValidateNumberIsPositiveOrNegative
{
    [MemoryDiagnoser(true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkTester
    {
        [Params(500)]
        public int Iteration;

        [Benchmark]
        public void ConditionalMethod()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var number = Random.Shared.Next(-20000, 20000);
                NumberValidation.IsPositiveOrNegativeUsingConditionalMethod(number);
            }
        }

        [Benchmark]
        public void LeftShiftMethod()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var number = Random.Shared.Next(-20000, 20000);
                NumberValidation.IsPositiveOrNegativeUsingLeftShiftMethod(number);
            }
        }

        [Benchmark]
        public void RightShiftMethod()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var number = Random.Shared.Next(-20000, 20000);
                NumberValidation.IsPositiveOrNegativeUsingRightShiftMethod(number);
            }
        }

        [Benchmark]
        public void MathAbsMethod()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var number = Random.Shared.Next(-20000, 20000);
                NumberValidation.IsPositiveOrNegativeUsingMathAbsMethod(number);
            }
        }

        [Benchmark]
        public void MathSignMethod()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var number = Random.Shared.Next(-20000, 20000);
                NumberValidation.IsPositiveOrNegativeUsingMathSignMethod(number);
            }
        }

        [Benchmark]
        public void BuiltInMethod()
        {
            for (int i = 0; i < Iteration; i++)
            {
                var number = Random.Shared.Next(-20000, 20000);
                NumberValidation.IsPositiveOrNegativeUsingBuiltInMethod(number);
            }
        }
    }
}
