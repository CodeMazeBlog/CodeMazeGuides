using BenchmarkDotNet.Running;
using HeapSort;

var summary = BenchmarkRunner.Run<HeapSortMethods>();
