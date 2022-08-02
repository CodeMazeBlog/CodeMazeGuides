using BenchmarkDotNet.Running;
using SelectionSort;

var summary = BenchmarkRunner.Run<Selection>();