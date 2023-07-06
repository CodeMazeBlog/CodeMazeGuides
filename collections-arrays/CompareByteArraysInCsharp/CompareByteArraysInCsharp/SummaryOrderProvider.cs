using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CompareByteArraysInCsharp
{
    [Config(typeof(Config))]
    [DryJob]
    [RankColumn]
    public class SummaryOrderProvider
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                Orderer = new CustomOrderer();
            }

            private class CustomOrderer : IOrderer
            {
                public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase,
                    IEnumerable<BenchmarkLogicalGroupRule> order = null)
                {
                    var sortedBenchmarks = benchmarksCase.OrderBy(b => b.Parameters["arrayName"].ToString())
                                                         .ThenBy(b => b.Descriptor.WorkloadMethodDisplayInfo);
                    return sortedBenchmarks;
                }

                public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary)
                {
                    var groupedBenchmarks = benchmarksCase.GroupBy(b => b.Parameters["arrayName"].ToString());

                    foreach (var group in groupedBenchmarks)
                    {
                        var sortedBenchmarks = group.OrderBy(b => summary[b].ResultStatistics.Mean);
                        foreach (var benchmark in sortedBenchmarks)
                        {
                            yield return benchmark;
                        }
                    }
                }

                public string GetHighlightGroupKey(BenchmarkCase benchmarkCase) => null;

                public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase) =>
                    benchmarkCase.Job.DisplayInfo + "_" + benchmarkCase.Parameters.DisplayInfo;

                public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
                    IEnumerable<BenchmarkLogicalGroupRule> order = null) => logicalGroups.OrderBy(it => it.Key);

                public bool SeparateLogicalGroups => true;
            }
        }
    }
}