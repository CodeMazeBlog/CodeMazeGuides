using System.Reflection;
using BenchmarkDotNet.Attributes;
using DynamicTypeInCSharp.Models;

namespace Benchmarks;

[InProcess]
[MemoryDiagnoser]
public class MethodCallBenchmarks
{
    private readonly Employee _employee = new() { Id = "1", Name = "Johnny Depp" };
    private readonly object _employeeObject;
    private readonly dynamic _employeeDynamic;

    public MethodCallBenchmarks()
    {
        _employeeObject = _employee;
        _employeeDynamic = _employee;
    }

    [Benchmark]
    public WorkStatus StaticCall() => _employee.GetWorkStatus();

    [Benchmark]
    public WorkStatus DynamicCall() => _employeeDynamic.GetWorkStatus();

    [Benchmark]
    public WorkStatus ReflectionCall() =>
        (WorkStatus)_employeeObject.GetType().InvokeMember("GetWorkStatus",
            BindingFlags.InvokeMethod, null, _employeeObject, null)!;
}
