using BenchmarkDotNet.Running;
using ShellSort;

var summary = BenchmarkRunner.Run<ShellSortMethods>();