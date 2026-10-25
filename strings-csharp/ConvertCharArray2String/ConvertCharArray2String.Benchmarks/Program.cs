using BenchmarkDotNet.Running;
using ConvertCharArray2String.Benchmarks;

BenchmarkRunner.Run<CharArrayToStringBenchmarks>(args: args);
