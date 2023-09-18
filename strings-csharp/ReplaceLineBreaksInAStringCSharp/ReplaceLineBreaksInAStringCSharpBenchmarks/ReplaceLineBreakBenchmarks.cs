using BenchmarkDotNet.Attributes;
using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpBenchmarks;

public  class ReplaceLineBreakBenchmarks
{
    [Benchmark]
    public string ReplaceUsingStringReplace() => ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceMethod();

    [Benchmark]
    public string ReplaceUsingStringReplaceLineEndings() => ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod();

    [Benchmark]
    public string ReplaceUsingRegularExpressionReplace() => ReplaceLineBreak.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod();
}
