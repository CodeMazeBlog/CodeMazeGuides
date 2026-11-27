using BenchmarkDotNet.Running;
using InsertionSort;

BenchmarkRunner.Run<InsertionSortBenchmarks>(args: args);
