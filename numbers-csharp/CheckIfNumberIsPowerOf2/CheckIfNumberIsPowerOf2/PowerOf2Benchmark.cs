using System.Numerics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace CheckIfNumberIsPowerOf2;

// exporters
[CsvExporter]
[CsvMeasurementsExporter]
[PlainExporter]
[RPlotExporter]

//diagnosers
[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class PowerOf2Benchmark {
    [Params(20000123, 16777216)]
    public int n;

    [Benchmark]
    public bool CheckWithLog() 
    {
        return PowerOf2Verifier.CheckWithLog(n);
    }

    [Benchmark]
    public bool CheckWithBitMaskV1() 
    {
        return PowerOf2Verifier.CheckWithBitMaskV1(n);
    }

    [Benchmark]
    public bool CheckWithBitMaskV2() 
    {
        return PowerOf2Verifier.CheckWithBitMaskV2(n);
    }

    [Benchmark]
    public bool CheckWithBitMaskV3() 
    {
        return PowerOf2Verifier.CheckWithBitMaskV3(n);
    }

    [Benchmark]
    public bool CheckWithBitOperationsBuiltIn() 
    {
        return BitOperations.IsPow2(n);
    }
}