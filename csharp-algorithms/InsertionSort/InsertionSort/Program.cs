using BenchmarkDotNet.Running;
using InsertionSort;

var summary = BenchmarkRunner.Run<InsertionSortMethods>();