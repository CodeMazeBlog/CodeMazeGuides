using BenchmarkDotNet.Running;
using DataTableToJsonTests;

BenchmarkDotNet.Reports.Summary summary;
summary = BenchmarkRunner.Run<Benchmark>();