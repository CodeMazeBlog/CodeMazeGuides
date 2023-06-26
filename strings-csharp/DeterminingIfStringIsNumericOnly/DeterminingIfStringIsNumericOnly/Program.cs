using BenchmarkDotNet.Running;
using IsStringNumber = DeterminingIfStringIsNumericOnly.IsStringNumber;

BenchmarkRunner.Run<IsStringNumber>();