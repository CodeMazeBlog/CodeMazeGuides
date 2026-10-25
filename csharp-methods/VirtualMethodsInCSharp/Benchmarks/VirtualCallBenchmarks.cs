using BenchmarkDotNet.Attributes;

namespace Benchmarks;

public class VirtualCallBenchmarks
{
    private const int Count = 1_000;

    private Circle[] _circles = [];
    private Shape[] _circlesAsShapes = [];
    private Shape[] _mixedShapes = [];
    private SealedCircle[] _sealedCircles = [];
    private IShape[] _circlesAsInterfaces = [];
    private Func<double>[] _delegates = [];

    [GlobalSetup]
    public void Setup()
    {
        _circles = Enumerable.Range(1, Count).Select(i => new Circle { Radius = i }).ToArray();
        _circlesAsShapes = _circles;
        _circlesAsInterfaces = _circles;
        _sealedCircles = Enumerable.Range(1, Count).Select(i => new SealedCircle { Radius = i }).ToArray();
        _mixedShapes = Enumerable.Range(1, Count)
            .Select(i => i % 2 == 0 ? (Shape)new Circle { Radius = i } : new Rectangle { Width = i, Height = 2 })
            .ToArray();
        _delegates = _circles.Select(c => (Func<double>)c.CalculateArea).ToArray();
    }

    [Benchmark(Baseline = true)]
    public double NonVirtual()
    {
        var total = 0.0;
        foreach (var circle in _circles)
            total += circle.CalculateAreaNonVirtual();
        return total;
    }

    [Benchmark]
    public double VirtualOneType()
    {
        var total = 0.0;
        foreach (var shape in _circlesAsShapes)
            total += shape.CalculateArea();
        return total;
    }

    [Benchmark]
    public double VirtualTwoTypes()
    {
        var total = 0.0;
        foreach (var shape in _mixedShapes)
            total += shape.CalculateArea();
        return total;
    }

    [Benchmark]
    public double VirtualOnSealedType()
    {
        var total = 0.0;
        foreach (var circle in _sealedCircles)
            total += circle.CalculateArea();
        return total;
    }

    [Benchmark]
    public double Interface()
    {
        var total = 0.0;
        foreach (var shape in _circlesAsInterfaces)
            total += shape.CalculateArea();
        return total;
    }

    [Benchmark]
    public double Delegate()
    {
        var total = 0.0;
        foreach (var calculateArea in _delegates)
            total += calculateArea();
        return total;
    }
}
