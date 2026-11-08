using BenchmarkDotNet.Running;
using HeapSort;

BenchmarkRunner.Run<HeapSortBenchmarks>(args: args);
