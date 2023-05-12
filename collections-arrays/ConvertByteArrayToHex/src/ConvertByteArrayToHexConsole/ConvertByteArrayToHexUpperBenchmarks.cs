using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using ConvertByteArrayToHexLibrary;

namespace ConvertByteArrayToHexConsole;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[RankColumn]
[MemoryDiagnoser]
public class ConvertByteArrayToHexUpperBenchmarks
{
    private static readonly int[] Sizes =
    {
        128,
        4096,
        //1_048_576
    };

    private readonly List<byte[]> _sourceData = new();

    public ConvertByteArrayToHexUpperBenchmarks()
    {
        var random = new Random(42);

        foreach (var size in Sizes)
        {
            var array = GC.AllocateUninitializedArray<byte>(size);
            random.NextBytes(array);
            _sourceData.Add(array);
        }
    }

    public IEnumerable<object> ArrayData()
    {
        foreach (var array in _sourceData)
            yield return array;
    }

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingBitConverter(byte[] source) => ConversionHelpers.ToHexStringWithBitConverter(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingBitConverterNoDashes(byte[] source) =>
        ConversionHelpers.ToHexStringWithBitConverter(source, true);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingStringBuilderAppend(byte[] source) =>
        ConversionHelpers.ToHexStringWithStringBuilderAppend(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingBitManipulation(byte[] source) =>
        ConversionHelpers.ToHexStringWithBitManipulation(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingAlphabetSpanLookup(byte[] source) =>
        ConversionHelpers.ToHexStringWithAlphabetSpanLookup(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingLookup(byte[] source) => ConversionHelpers.ToHexStringWithLookup(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingLookupNetStandard20(byte[] source) =>
        ConversionHelpers.ToHexStringWithLookupNetStandard20(source);

    [Benchmark]
    [ArgumentsSource(nameof(ArrayData))]
    public string ConvertToHexUsingConvert(byte[] source) => ConversionHelpers.ToHexStringWithConvert(source);
}