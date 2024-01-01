using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConvertingStringToByteArray;

namespace ConvertStringToByteArrayBenchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class LongMessageConversionBenchmark
{
    const string LongMessage = "Welcome to CodeMaze, your one-stop destination for mastering all things .NET and C#! Explore a comprehensive learning experience tailored to your programming journey.";

    [Benchmark]
    public byte[] ConvertLongMessageToUTF8Bytes() => MessageConversion.ConvertStringToUTF8Bytes(LongMessage);

    [Benchmark]
    public byte[] ConvertLongMessageUsingCasting() => MessageConversion.ConvertStringToByteArrayUsingCasting(LongMessage);

    [Benchmark]
    public byte[] ConvertLongMessageUsingConvertToByte() => MessageConversion.ConvertStringToByteArrayUsingConvertToByte(LongMessage);

    [Benchmark]
    public byte[] ConvertLongMessageUsingGetEncoding() => MessageConversion.ConvertStringToByteArrayUsingEncoding(LongMessage);
}
