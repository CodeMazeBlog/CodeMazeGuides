using BenchmarkDotNet.Running;
using ConvertByteArrayToHexConsole;

BenchmarkRunner.Run<ConvertByteArrayToHexUpperBenchmarks>();
BenchmarkRunner.Run<ConvertByteArrayToHexLowerBenchmarks>();