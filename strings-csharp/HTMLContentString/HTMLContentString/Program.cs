using BenchmarkDotNet.Running;
using HTMLContentString;

var summary = BenchmarkRunner.Run<GetHtmlStringBenchmark>();