using BenchmarkDotNet.Running;
using GrpcVsRest.Benchmarks;

switch (args)
{
    case ["demo"]:
        await Demo.RunAsync();
        break;
    case ["sizes"]:
        PayloadSizes.Print();
        break;
    case ["wire"]:
        await WireBytes.PrintAsync();
        break;
    default:
        BenchmarkSwitcher.FromAssembly(typeof(CallBenchmarks).Assembly).Run(args);
        break;
}
