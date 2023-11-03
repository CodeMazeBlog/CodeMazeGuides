using BenchmarkDotNet.Attributes;

namespace UsingStaticAnonymousFunctionsInCSharp
{
    [MemoryDiagnoser]
    public class AnonymousFunctionsBenchmark
    {
        private double numNonConst = 4;
        private const double numConst = 4;

        void Calculate(Func<double, double> func)
        {
            Console.WriteLine(func(6));
        }

        [Benchmark]
        public void DisplayNonStaticOnce()
        {
            Calculate(num => Math.Pow(numNonConst, num));
        }

        [Benchmark]
        public void DisplayStaticOnce()
        {
            Calculate(static num => Math.Pow(numConst, num));
        }

        [Benchmark]
        public void DisplayNonStaticLoop()
        {
            for (int i = 0; i < 1000; i++)
            {
                Calculate(num => Math.Pow(numNonConst, num));
            }
        }

        [Benchmark]
        public void DisplayStaticLoop()
        {
            for (int i = 0; i < 1000; i++)
            {
                Calculate(static num => Math.Pow(numConst, num));
            }
        }
    }
}
