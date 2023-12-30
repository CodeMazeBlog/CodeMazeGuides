// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ConvertStringToByteArrayBenchmark;

BenchmarkRunner.Run<ShortMessageConversionBenchmarks>();
BenchmarkRunner.Run<LongMessageConversionBenchmarks>();

