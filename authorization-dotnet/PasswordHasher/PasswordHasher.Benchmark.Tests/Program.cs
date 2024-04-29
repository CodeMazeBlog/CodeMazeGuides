using BenchmarkDotNet.Running;
using PasswordHasher.Benchmark.Tests;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);