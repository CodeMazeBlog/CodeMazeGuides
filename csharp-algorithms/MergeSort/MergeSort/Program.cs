using BenchmarkDotNet.Running;
using MergeSort;

BenchmarkRunner.Run<MergeBenchmarks>(args: args);
