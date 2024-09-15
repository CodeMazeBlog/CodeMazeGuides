using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PasswordHasher.Api.Models;

namespace PasswordHasher.Benchmark.Tests;

public class PasswordHasherV3Benchmark
{
    [Params(1000, 10_000, 100_000, 1_000_000)]
    public int IterationCount;

    private PasswordHasher<RegisteredUser> _sut;

    [IterationSetup]
    public void Setup()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
            IterationCount = IterationCount
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        _sut = new PasswordHasher<RegisteredUser>(options); 
    }
    
    [Benchmark]
    public void PasswordHasherWithIdentityV3()
    {
        var result = _sut.HashPassword(null, "cleverGreenHouse7");
    }
}