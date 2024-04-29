using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PasswordHasher.Api.Models;

namespace PasswordHasher.Benchmark.Tests;

public class PasswordHasherV2Benchmark
{
    [Benchmark]
    public void PasswordHasherWithIdentityV2()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);

        var result = sut.HashPassword(null, "cleverGreenHouse7");
    }
}