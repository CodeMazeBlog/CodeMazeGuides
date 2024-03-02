using BenchmarkDotNet.Running;
using GenerateRandomBooleans;
using GenerateRandomBooleans.AlgorithmBenchmarks;

BenchmarkRunner.Run<BenchmarkRandomGenerators>();
// BenchmarkRunner.Run<BenchmarkFirstThreeGenerators>();
// BenchmarkRunner.Run<BenchmarkFirstThreePlusDirectGetItems>();
// BenchmarkRunner.Run<BenchmarkGetItemsWithBufferGenerator>();
// BenchmarkRunner.Run<BenchmarkGetItemsWithBufferGeneratorVsNextIntegerGenerator>();
// BenchmarkRunner.Run<BenchmarkNextIntegerBitsGeneratorVsNextIntegerGenerator>();
// BenchmarkRunner.Run<BenchmarkNextIntegerBitsGeneratorVsNextLongBitsGenerator>();
// FairnessTest.Test();
