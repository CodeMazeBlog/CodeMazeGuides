using BenchmarkDotNet.Running;
using CountingSort;

BenchmarkRunner.Run<CountingSortBenchmarks>(args: args);
