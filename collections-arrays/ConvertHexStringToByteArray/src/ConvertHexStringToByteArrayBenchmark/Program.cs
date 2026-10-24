using BenchmarkDotNet.Running;
using ConvertHexStringToByteArray.Benchmarks;

BenchmarkRunner.Run<ConvertHexStringToByteArrayBenchmarks>(args: args);