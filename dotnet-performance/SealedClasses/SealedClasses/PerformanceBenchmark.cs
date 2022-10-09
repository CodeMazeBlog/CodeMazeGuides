using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace SealedClasses
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class PerformanceBenchmark
    {
        private readonly Bear _bear = new();
        private readonly Husky _husky = new();
        private readonly Animal _animal = new();

        private readonly Bear[] _bears = new Bear[1];
        private readonly Husky[] _huskies = new Husky[1];

        [Benchmark]
        public void Sealed_VoidMethod() => _husky.DoNothing();

        [Benchmark]
        public void Open_VoidMethod() => _bear.DoNothing();

        [Benchmark]
        public int Sealed_IntMethod() => _husky.GetAge();

        [Benchmark]
        public int Open_IntMethod() => _bear.GetAge();

        [Benchmark]
        public void Sealed_StaticMethod() => Husky.Walk();

        [Benchmark]
        public void Open_StaticMethod() => Bear.Walk();

        [Benchmark]
        public string Sealed_ToString() => _husky.ToString()!;

        [Benchmark]
        public string Open_ToString() => _bear.ToString()!;

        [Benchmark]
        public Husky? Sealed_Casting() => _animal as Husky;

        [Benchmark]
        public Bear? Open_Casting() => _animal as Bear;

        [Benchmark]
        public bool Sealed_TypeCheck() => _animal is Husky;

        [Benchmark]
        public bool Open_TypeCheck() => _animal is Bear;

        [Benchmark]
        public void Sealed_AddToArray() => _huskies[0] = new Husky();

        [Benchmark]
        public void Open_AddToArray() => _bears[0] = new Bear();

        [Benchmark]
        public void SealedDeclaredInMethod_VoidMethod()
        {
            var husky = new Husky();
            husky.DoNothing();
        }

        [Benchmark]
        public void OpenDeclaredInMethod_VoidMethod()
        {
            var bear = new Bear();
            bear.DoNothing();
        }
    }
}
