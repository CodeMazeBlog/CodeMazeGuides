// See https://aka.ms/new-console-template for more information

using App;
using BenchmarkDotNet.Running;

Console.WriteLine(Convert.ToBase64String(CryptographicHelpers.GenerateRandomKey(32)));
Console.WriteLine(CryptographicHelpers.GenerateRandomInteger(1, 100));
var summary = BenchmarkRunner.Run<RandomNumberBenchmarks>();