using BenchmarkDotNet.Running;
using Bogus;
using RemoveWhitespaceCharactersFromStringBenchmarks;

// Initialize random seed to static value for reproducible results
Randomizer.Seed = new Random(42);

BenchmarkRunner.Run<ReplaceWhitespaceBenchmarks>();
BenchmarkRunner.Run<TrimWhitespaceBenchmarks>();