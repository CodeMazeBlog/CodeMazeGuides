using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<MaxElement>();

// var summary = BenchmarkRunner.Run<Convolution>();

