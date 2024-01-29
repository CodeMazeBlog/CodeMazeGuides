using BenchmarkDotNet.Running;
using CountFilesInaFolderBenchmarks;

var summary = BenchmarkRunner.Run<FileCountingBenchmark>();