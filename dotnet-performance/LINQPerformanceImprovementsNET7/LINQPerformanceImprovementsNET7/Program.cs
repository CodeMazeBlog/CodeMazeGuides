using BenchmarkDotNet.Running;
using LINQPerformanceImprovementsNET7;

BenchmarkDotNet.Reports.Summary summary;
summary = BenchmarkRunner.Run<Benchmark>();