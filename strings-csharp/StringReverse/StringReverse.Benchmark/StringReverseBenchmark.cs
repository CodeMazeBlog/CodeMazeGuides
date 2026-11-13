using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using StringReverse;

namespace BenchmarkRunner;

[InProcess]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringReverseBenchmark
{
    private string _randomString = string.Empty;

    [Params(64, 1024)]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() => _randomString = GenerateText(Length);

    [Benchmark]
    public string UsingArrayReverseString() => Methods.ArrayReverseString(_randomString);

    [Benchmark]
    public string UsingStringCreateMethod() => Methods.StringCreateMethod(_randomString);

    [Benchmark]
    public string UsingStringBuilderReverseMethod() => Methods.StringBuilderReverseMethod(_randomString);

    [Benchmark]
    public string UsingReverseXorMethod() => Methods.ReverseXorMethod(_randomString);

    [Benchmark]
    public string UsingEnumerableReverseMethod() => Methods.EnumerableReverseMethod(_randomString);

    [Benchmark]
    public string UsingRecursiveStringReverseMethod() => Methods.RecursiveStringReverseMethod(_randomString);

    [Benchmark]
    public string UsingStackReverseMethod() => Methods.StackReverseMethod(_randomString);

    [Benchmark]
    public string UsingStringExtensionReverseMethod() => Methods.StringExtensionReverseMethod(_randomString);

    [Benchmark]
    public string UsingTextElementEnumeratorReverseMethod() => Methods.TextElementEnumeratorMethod(_randomString);

    public static string GenerateText(int length)
    {
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var builder = new StringBuilder(length);

        for (int i = 0; i < length; ++i)
        {
            var index = random.Next(alphabet.Length);

            builder.Append(alphabet[index]);
        }

        return builder.ToString();
    }
}
