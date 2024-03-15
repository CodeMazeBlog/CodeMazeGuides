using System.Text;
using BenchmarkDotNet.Attributes;

namespace App;

[MemoryDiagnoser]
public class UTF8Benchmarks
{
    [Benchmark]
    public byte[] OldSyntax()
    {
       return Encoding.UTF8.GetBytes("Hello World!");
    }
    
    [Benchmark]
    public ReadOnlySpan<byte> NewSyntax()
    {
        return "Hello World!"u8;
    }
}