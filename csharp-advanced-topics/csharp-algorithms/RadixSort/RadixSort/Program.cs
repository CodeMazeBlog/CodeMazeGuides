using BenchmarkDotNet.Running;
using RadixSort;

var summary = BenchmarkRunner.Run<RadixSortMethods>();