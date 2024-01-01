// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ConvertStringToByteArrayBenchmark;

BenchmarkRunner.Run<ShortMessageConversionBenchmark>();
BenchmarkRunner.Run<LongMessageConversionBenchmark>();

