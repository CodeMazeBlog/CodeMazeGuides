using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using StringReverse;
using System.Text;

namespace BenchmarkRunner
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class StringReverseBenchmark
    {        
        private readonly string _randomString = GenerateText();

        [Benchmark]
        public void UsingArrayReverseString()
        {
            Methods.ArrayReverseString(_randomString);
        }

        [Benchmark]
        public void UsingStringCreateMethod()
        {
            Methods.StringCreateMethod(_randomString);
        }

        [Benchmark]
        public void UsingStringBuilderReverseMethod()
        {
            Methods.StringBuilderReverseMethod(_randomString);
        }

        [Benchmark]
        public void UsingReverseXorMethod()
        {
            Methods.ReverseXorMethod(_randomString);
        }

        [Benchmark]
        public void UsingEnumerableReverseMethod()
        {
            Methods.EnumerableReverseMethod(_randomString);
        }

        [Benchmark]
        public void UsingRecursiveStringReverseMethod()
        {
            Methods.RecursiveStringReverseMethod(_randomString);
        }

        [Benchmark]
        public void UsingStackReverseMethod()
        {
            Methods.StackReverseMethod(_randomString);
        }

        [Benchmark]
        public void UsingStringExtensionReverseMethod()
        {
            Methods.StringExtensionReverseMethod(_randomString);
        }

        [Benchmark]
        public void UsingTextElementEnumeratorReverseMethod()
        {
            Methods.TextElementEnumeratorMethod(_randomString);
        }

        public static string GenerateText()
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var length = 64;
            var builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
            {
                var index = random.Next(alphabet.Length);

                builder.Append(alphabet[index]);
            }

            return builder.ToString();
        }
    }
}
