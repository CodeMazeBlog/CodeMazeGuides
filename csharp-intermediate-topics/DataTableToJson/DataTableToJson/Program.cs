using BenchmarkDotNet.Running;
using DataTableToJsonTests;

BenchmarkDotNet.Reports.Summary summary;
if (args.Length > 0 && args[0].Equals("10000"))
    _ = BenchmarkRunner.Run<Benchmark_10000>();
else if (args.Length > 0 && args[0].Equals("100000"))
    summary = BenchmarkRunner.Run<Benchmark_100000>();
else if (args.Length > 0 && args[0].Equals("1000000"))
    summary = BenchmarkRunner.Run<Benchmark_1000000>();
else
    summary = BenchmarkRunner.Run<Benchmark>();


