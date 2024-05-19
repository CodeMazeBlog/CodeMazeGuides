using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PasswordHasher.Api.Models;

namespace PasswordHasher.Benchmark.Tests;

public class PasswordHasherV2Benchmark
{
    private PasswordHasher<RegisteredUser> _sut;

    [IterationSetup]
    public void Setup()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        _sut = new PasswordHasher<RegisteredUser>(options); 
    }   
    
    [Benchmark]
    public void PasswordHasherWithIdentityV2()
    {
        var result = _sut.HashPassword(null, "cleverGreenHouse7");
    }
}