using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PasswordHasher.Api.Models;

namespace PasswordHasher.Benchmark.Tests;

public class PasswordHasherV3Benchmark
{
    [Params(1000, 10_000, 100_000, 1_000_000)]
    public int IterationCount;

    [Benchmark]
    public void PasswordHasherWithIdentityV3()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
            IterationCount = IterationCount
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);

        var result = sut.HashPassword(null, "cleverGreenHouse7");
    }
}