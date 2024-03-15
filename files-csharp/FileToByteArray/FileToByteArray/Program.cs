using BenchmarkDotNet.Running;
using FileToByteArray;

BenchmarkRunner.Run<GiantFileBenchmarks>();
BenchmarkRunner.Run<LargeFileBenchmarks>();