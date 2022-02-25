using BenchmarkDotNet.Running;
using BubbleSort;

var summary = BenchmarkRunner.Run<Bubble>();