using BenchmarkDotNet.Running;
using SubstringInString;

SubstringMethod.Substringmethod();
IndexOfMethod.Indexofmethod();
RegexMethod.Regexmethod();
LinqMethod.Linqmethod();
SplitMethod.Splitmethod();

//var summary = BenchmarkRunner.Run<Benchmark>();

//// Output summary
//Console.WriteLine(summary);