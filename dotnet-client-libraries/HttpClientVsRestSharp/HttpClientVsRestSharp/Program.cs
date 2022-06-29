using BenchmarkDotNet.Running;
using HttpClientVsRestSharp;

var summary = BenchmarkRunner.Run<TodoBenchmark>();