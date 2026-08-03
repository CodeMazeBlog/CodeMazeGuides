using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConvertingStringToByteArray;

namespace ConvertStringToByteArrayBenchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ShortMessageConversionBenchmark
{
    const string ShortMessage = "Welcome to CodeMaze!";

    [Benchmark]
    public byte[] ConvertShortMessageToUTF8Bytes() => MessageConversion.ConvertStringToUTF8Bytes(ShortMessage);

    [Benchmark]
    public byte[] ConvertShortMessageUsingCasting() => MessageConversion.ConvertStringToByteArrayUsingCasting(ShortMessage);

    [Benchmark]
    public byte[] ConvertShortMessageUsingConvertToByte() => MessageConversion.ConvertStringToByteArrayUsingConvertToByte(ShortMessage);

    [Benchmark]
    public byte[] ConvertShortMessageUsingGetEncoding() => MessageConversion.ConvertStringToByteArrayUsingEncoding(ShortMessage);
}