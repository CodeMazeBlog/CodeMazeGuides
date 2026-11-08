using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(MaxElement).Assembly).Run(args);

