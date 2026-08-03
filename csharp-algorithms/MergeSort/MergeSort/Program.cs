using BenchmarkDotNet.Running;
using MergeSort;

var summary = BenchmarkRunner.Run<Merge>();