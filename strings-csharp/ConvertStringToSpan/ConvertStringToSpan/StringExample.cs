using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Order;

namespace ConvertStringToSpan
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class StringExample
    {
        private string myString = "Hello, World!";
        [Benchmark]
        public Span<char> ConvertStringToSpanUsingMemoryMarshal()
        {
            var charArray = myString.ToCharArray();
            var memory = new Memory<char>(charArray);
            var span = MemoryMarshal.Cast<char, char>(memory.Span);

            return span;
        }

        [Benchmark]
        public unsafe Span<char> ConvertStringToSpanUsingUnsafe()
        {
            unsafe
            {
                fixed (char* ptr = myString)
                {
                    return new Span<char>(ptr, myString.Length);
                }
            }
        }

        [Benchmark]
        public ReadOnlySpan<char> ConvertStringToReadOnlySpanUsingAsSpan()
        {
            var span = myString.AsSpan();

            return span;
        }

        [Benchmark]
        public Span<char> ConvertStringToSpanUsingAsSpan()
        {
            var span = myString.AsSpan();

            return span.ToArray();
        }

        [Benchmark]
        public ReadOnlySpan<char> ConvertStringToSpan()
        {
            var span = myString;

            return span;
        }
    }
}
