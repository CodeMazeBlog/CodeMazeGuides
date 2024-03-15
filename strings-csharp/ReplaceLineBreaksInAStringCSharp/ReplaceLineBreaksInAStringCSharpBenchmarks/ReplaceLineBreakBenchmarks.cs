using BenchmarkDotNet.Attributes;
using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpBenchmarks;

[MemoryDiagnoser]
public  class ReplaceLineBreakBenchmarks
{
    [Benchmark]
    public string StringReplace() => ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceMethod();

    [Benchmark]
    public string StringReplaceLineEndings() => ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();

    [Benchmark]
    public string RegexReplace() => ReplaceLineBreak.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();
}
