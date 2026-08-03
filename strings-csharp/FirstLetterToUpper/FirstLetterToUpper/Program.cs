using BenchmarkDotNet.Running;
using FirstLetterToUpper;

var summary = BenchmarkRunner.Run<FirstLetterToUpperMethods>();
