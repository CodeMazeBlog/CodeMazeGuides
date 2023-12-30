using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConvertingStringToByteArray;

namespace ConvertStringToByteArrayBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class MessageConversionBenchmarks
{
    const string Message = "Welcome to CodeMaze!";
    /*const string ShortMessage = "Hello";
    const string MediumMessage = "This is a longer string with some more characters.";
    const string LongMessage = "This is a very long string that will be used to test performance with a larger amount of data.";*/

    [Benchmark]
    public byte[] ConvertStringToUTF8Bytes_ShortMessage() => MessageConversion.ConvertStringToUTF8Bytes(Message);

    [Benchmark]
    public byte[] ConvertStringToByteArrayUsingCasting_ShortMessage() => MessageConversion.ConvertStringToByteArrayUsingCasting(Message);

    [Benchmark]
    public byte[] ConvertStringToByteArrayUsingConvertToByte_ShortMessage() => MessageConversion.ConvertStringToByteArrayUsingConvertToByte(Message);

    [Benchmark]
    public byte[] ConvertStringToByteArrayUsingEncoding_ShortMessage() => MessageConversion.ConvertStringToByteArrayUsingEncoding(Message);

    // Repeat for MediumMessage and LongMessage
}
