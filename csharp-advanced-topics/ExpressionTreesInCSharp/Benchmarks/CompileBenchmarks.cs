using BenchmarkDotNet.Attributes;
using ExpressionTreesInCSharp;
using System.Linq.Expressions;

namespace Benchmarks;

[MemoryDiagnoser]
public class CompileBenchmarks
{
    private readonly Expression<Func<int, int, int>> _sumExpressionTree =
        ExpressionTrees.CreateExpressionTreeFromLambdaExpression();

    private readonly Func<int, int, int> _lambda = ExpressionTrees.CreateLambdaExpression();
    private Func<int, int, int> _compiled = default!;
    private Func<int, int, int> _interpreted = default!;

    [GlobalSetup]
    public void Setup()
    {
        _compiled = _sumExpressionTree.Compile();
        _interpreted = _sumExpressionTree.Compile(preferInterpretation: true);
    }

    [Benchmark]
    public int InvokeLambda() => _lambda(1, 2);

    [Benchmark]
    public int InvokeCachedCompiledDelegate() => _compiled(1, 2);

    [Benchmark]
    public int InvokeCachedInterpretedDelegate() => _interpreted(1, 2);

    [Benchmark]
    public int CompileAndInvoke() => _sumExpressionTree.Compile()(1, 2);

    [Benchmark]
    public int InterpretAndInvoke() => _sumExpressionTree.Compile(preferInterpretation: true)(1, 2);
}
