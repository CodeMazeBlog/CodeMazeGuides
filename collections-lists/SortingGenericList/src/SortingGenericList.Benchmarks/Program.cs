using BenchmarkDotNet.Running;
using SortingGenericList.Benchmarks;

BenchmarkRunner.Run<AddingSingleItemsBenchmark>();
BenchmarkRunner.Run<SortingWithCompare>();