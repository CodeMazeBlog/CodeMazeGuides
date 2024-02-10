using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace HowToUseStringPool.Benchmark;

public class AntiVirusFriendlyConfig : ManualConfig
{
    public AntiVirusFriendlyConfig()
    {
        AddJob(Job.MediumRun
            .WithToolchain(InProcessNoEmitToolchain.Instance));
    }
}