using BenchmarkDotNet.Running;
using CountingSort;

var summary = BenchmarkRunner.Run<CountingSortMethods>();