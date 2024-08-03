using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using System.Numerics;

namespace SIMDAcceleratedNumericTypes;

[MemoryDiagnoser]
[Config(typeof(StyleConfig))]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[HideColumns(Column.AllocRatio, Column.Gen0, Column.RatioSD)]
public class SIMDNumericTypesBenchmark
{
    public class StyleConfig : ManualConfig
    {
        public StyleConfig()
        {
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
        }
    }

    [Benchmark]
    public Matrix4x4 CreateAndMultiplyTwoMatricesWithSIMD()
        => SIMDNumericTypesOperations.CreateAndMultiplyTwoMatricesWithSIMD();

    [Benchmark(Baseline = true)]
    public float[,] CreateAndMultiplyTwoMatricesWithoutSIMD()
        => SIMDNumericTypesOperations.CreateAndMultiplyTwoMatricesWithoutSIMD();
}