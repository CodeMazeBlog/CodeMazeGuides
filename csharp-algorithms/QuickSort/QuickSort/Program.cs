using BenchmarkDotNet.Running;
using QuickSort;

var summary = BenchmarkRunner.Run<QuickSortMethods>();