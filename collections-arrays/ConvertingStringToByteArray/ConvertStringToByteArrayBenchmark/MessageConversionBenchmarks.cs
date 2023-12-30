using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConvertingStringToByteArray;

namespace ConvertStringToByteArrayBenchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ShortMessageConversionBenchmarks
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

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class LongMessageConversionBenchmarks()
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