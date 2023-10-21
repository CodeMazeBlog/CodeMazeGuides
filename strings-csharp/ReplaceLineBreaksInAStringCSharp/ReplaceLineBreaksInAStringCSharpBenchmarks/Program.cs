using BenchmarkDotNet.Running;
using ReplaceLineBreaksInAStringCSharpBenchmarks;

var summary = BenchmarkRunner.Run<ReplaceLineBreakBenchmarks>();
Console.WriteLine(summary);
