using System.Text;
using BenchmarkDotNet.Attributes;

namespace App;

[MemoryDiagnoser]
public class UTF8Benchmarks
{
    [Benchmark]
    public byte[] OldSyntax()
    {
        var returnValue = Encoding.UTF8.GetBytes("Hello World!");
        return returnValue;
    }
    
    [Benchmark]
    public ReadOnlySpan<byte> NewSyntax()
    {
        var returnValue = "Hello World!"u8;
        return returnValue;
    }
}