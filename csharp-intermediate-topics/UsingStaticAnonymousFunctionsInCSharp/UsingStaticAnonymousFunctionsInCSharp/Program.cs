using BenchmarkDotNet.Running;
using UsingStaticAnonymousFunctionsInCSharp;
using UsingStaticAnonymousFunctionsInCSharp.Demo;

// non-static anonymous function
Console.WriteLine("non-static anonymous function");
new DemoNonStatic().Display();
Console.WriteLine();

// static anonymous function with const variable in enclosing scope
Console.WriteLine("static anonymous function with const variable in enclosing scope");
new DemoStaticWithConstVariable().Display();
Console.WriteLine();

// static anonymous function with static variable in enclosing scope
Console.WriteLine("static anonymous function with static variable in enclosing scope");
new DemoStaticWithStaticVariable().Display();
Console.WriteLine();

// static anonymous function with non-static local method
Console.WriteLine("static anonymous function with non-static local method");
new DemoStaticWithNonStaticLocalMethod().Display();
Console.WriteLine();

// Benchmarks
BenchmarkRunner.Run<AnonymousFunctionsBenchmark>();
