using App;
using BenchmarkDotNet.Running;

Console.WriteLine(Convert.ToBase64String(CryptographicHelpers.GenerateSecureRandomKey(32)));
Console.WriteLine(CryptographicHelpers.GenerateSecureRandomInteger(1, 100));
BenchmarkRunner.Run<RandomNumberBenchmarks>();